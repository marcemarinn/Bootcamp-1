using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Context;
using Mapster;

namespace Infrastructure.Repositories;

public class TransferRepository : ITransferRepository
{
    private readonly Bootcampp2Context _bootcampp2Context;

    public TransferRepository(Bootcampp2Context bootcampp2Context)
    {
        _bootcampp2Context = bootcampp2Context;
    }



        public async Task<TransferDTO> Create(TransferRequest request)

        {
            var transferToCreate = request.Adapt<Transfer>();
            transferToCreate.TransferDateTime = DateTime.UtcNow;

        var senderAccount = await _bootcampp2Context.Accounts.FindAsync(request.SenderId);
        var receiverAccount = await _bootcampp2Context.Accounts.FindAsync(request.ReceiverId);
        var senderCustomer = await _bootcampp2Context.Customers.FindAsync(senderAccount.CustomerId);
        var receiverCustomer = await _bootcampp2Context.Customers.FindAsync(receiverAccount.CustomerId);

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


            _bootcampp2Context.Transfers.Add(transferToCreate);
            await _bootcampp2Context.SaveChangesAsync();

            return transferToCreate.Adapt<TransferDTO>();

        }

    }

