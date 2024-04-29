using Core.Constants;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            throw new NotFoundException("One or both accounts were not found.");
        }

        if (senderAccount.Type != receiverAccount.Type)
        {
            throw new NotFoundException("The accounts are not of the same type.");
        }

        if (senderAccount.CurrencyId != receiverAccount.CurrencyId)
        {
            throw new NotFoundException("The accounts do not have the same currency.");
        }

        if (request.Amount > senderAccount.Balance)
        {
            throw new NotFoundException("The transfer amount is greater than the current balance of the originating account.");
        }

        if (receiverAccount.IsDeleted)
        {
            throw new NotFoundException("The receiver account is not active.");
        }

        


        var senderBankId = await _bootcampContext.Customers
         .Where(c => c.Id == senderAccount.CustomerId)
         .Select(c => c.BankId)
         .FirstOrDefaultAsync();

        var receiverBankId = await _bootcampContext.Customers
            .Where(c => c.Id == receiverAccount.CustomerId)
            .Select(c => c.BankId)
            .FirstOrDefaultAsync();

        if (senderBankId == receiverBankId)
        {

            senderAccount.Balance -= request.Amount;
            receiverAccount.Balance += request.Amount;

            _bootcampContext.Transfers.Add(transferToCreate);
        }
        else { 

        var receiverBank = await _bootcampContext.Banks.FindAsync(receiverBankId);

        if (senderBankId != receiverBankId)
        {
            var externalAccount = new ExternalAccount
            {
                DocumentNumber = request.DocumentNumber,
                BankId = request.BankId,
                NumberAccount = request.NumberAccount,
                CurrencyId = request.CurrencyId
            };
            _bootcampContext.ExternalAccounts.Add(externalAccount);

            senderAccount.Balance -= request.Amount;
            receiverAccount.Balance += request.Amount;

            
        }
        }


        var movementToCreate = new Movement
        {
            AccountId = request.SenderId,
            Amount = request.Amount,
            OperationalDate = request.TransferDateTime,
            Description = request.Description,
            TransactionType = TransactionType.EServicePayment
        };

        _bootcampContext.Movements.Add(movementToCreate);
        

        await _bootcampContext.SaveChangesAsync();

        return transferToCreate.Adapt<TransferDTO>();
    }

}