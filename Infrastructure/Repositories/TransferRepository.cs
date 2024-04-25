using Core.Constants;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
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
            throw new Exception("One or both accounts were not found.");
        }

        if (senderAccount.Type != receiverAccount.Type || senderAccount.Currency != receiverAccount.Currency)
        {
            throw new NotFoundException("The accounts are not of the same type or do not have the same currency.");
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

      
        _bootcampContext.Transfers.Add(transferToCreate);
        await _bootcampContext.SaveChangesAsync();

        return transferToCreate.Adapt<TransferDTO>();
    }

}
