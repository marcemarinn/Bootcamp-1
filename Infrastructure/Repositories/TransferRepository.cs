using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;

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
        var senderCustomer = await _bootcampContext.Customers.FindAsync(senderAccount.CustomerId);
        var receiverCustomer = await _bootcampContext.Customers.FindAsync(receiverAccount.CustomerId);

        if (senderCustomer.BankId != receiverCustomer.BankId)
        {
            throw new Exception("Por favor, completa el campo del banco de destino.");
        }

        //if (senderAccount is null) throw new Exception("senderId was not found");
        //if (receiverAccount is null) throw new Exception("receiverId was not found");
        //if (request.Amount > senderAccount.Balance) throw new Exception("balance limit");
        //if (senderAccount.IsDeleted == true) throw new Exception("Origin Acccount is not active");
        //if (senderAccount.Balance < request.Amount) throw new Exception("senders account balance is insufficient.");
        //if (senderAccount.Type == receiverAccount.Type)



        senderAccount.Balance -= request.Amount;
        receiverAccount.Balance += request.Amount;


        _bootcampContext.Transfers.Add(transferToCreate);
        await _bootcampContext.SaveChangesAsync();

        return transferToCreate.Adapt<TransferDTO>();

    }
}
