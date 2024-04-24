using Core.Constants;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TransferRepository : ITransferRepository
{

    private readonly BootcampContext _bootcampContext;

    public TransferRepository(BootcampContext bootcampContext)
    {
        _bootcampContext = bootcampContext;
    }


    public async Task<TransferDTO> Create(TransferRequest request)

    {
        var transferToCreate = request.Adapt<Transfer>();
        transferToCreate.TransferDateTime = DateTime.UtcNow;

        var senderAccount = await _bootcampContext.Accounts.FindAsync(request.SenderId);
        var receiverAccount = await _bootcampContext.Accounts.FindAsync(request.ReceiverId);

        if (senderAccount == null || receiverAccount == null)
        {
            throw new Exception("Una o ambas cuentas no fueron encontradas.");
        }

        var senderCustomerBankId = await _bootcampContext.Customers
            .Where(c => c.Id == senderAccount.CustomerId)
            .Select(c => c.BankId)
            .FirstOrDefaultAsync();

        var receiverCustomerBankId = await _bootcampContext.Customers
            .Where(c => c.Id == receiverAccount.CustomerId)
            .Select(c => c.BankId)
            .FirstOrDefaultAsync();

        if (senderCustomerBankId != receiverCustomerBankId)
        {
            throw new Exception("Por favor, completa el campo del banco de destino.");
        }

        if (senderAccount.Type != receiverAccount.Type || senderAccount.Currency != receiverAccount.Currency)
        {
            throw new Exception("Las cuentas no son del mismo tipo o no tienen la misma moneda.");
        }

        if (request.Amount > senderAccount.Balance)
        {
            throw new NotFoundException("El monto de transferencia es mayor que el saldo actual de la cuenta origen.");
        }

        if (senderAccount.IsDeleted)
        {
            throw new NotFoundException("La cuenta de origen no está activa.");
        }

        // Verificar si la operación sobrepasa el límite operacional
        var transactionLimit = await _bootcampContext.TransactionLimits
            .Where(tl => tl.TransactionType == TransactionType.ETransfer &&
                         tl.OriginAccountId == request.SenderId &&
                         tl.DestinationAccountId == request.ReceiverId)
            .FirstOrDefaultAsync();

        if (transactionLimit != null && request.Amount > transactionLimit.TransactionalLimit)
        {
            throw new NotFoundException("La operación sobrepasa el límite operacional.");
        }

        senderAccount.Balance -= request.Amount;
        receiverAccount.Balance += request.Amount;

        _bootcampContext.Transfers.Add(transferToCreate);
        await _bootcampContext.SaveChangesAsync();

        return transferToCreate.Adapt<TransferDTO>();
    }

}
