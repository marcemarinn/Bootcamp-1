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
        var receiverBank = await _bootcampContext.Accounts.FindAsync(request.ReceiverBankId);
        var senderBank = await _bootcampContext.Accounts.FindAsync(request.SenderId);



        if (senderBank == receiverBank)
        {

            if (senderAccount == null || receiverAccount == null)
            {
                throw new Exception("One or both accounts were not found.");
            }

            if (senderAccount.Type != receiverAccount.Type)
            {
                throw new NotFoundException("The accounts are not of the same type ");
            }

            if (senderAccount.Currency != receiverAccount.Currency)
            {
                throw new NotFoundException("The accounts do not have the same currency.");
            }


            if (request.Amount > senderAccount.Balance)
            {
                throw new NotFoundException("The transfer amount is greater than the current balance of the originating account.");
            }


            if (senderAccount.IsDeleted)
            {
                throw new NotFoundException("The source account is not active.");
            }


            senderAccount.Balance -= request.Amount;
            receiverAccount.Balance += request.Amount;

        }

        if (senderBank != receiverBank)
        {



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
        _bootcampContext.Transfers.Add(transferToCreate);
        await _bootcampContext.SaveChangesAsync();

        return transferToCreate.Adapt<TransferDTO>();
    }

}
