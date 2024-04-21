using Core.Constants;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests;
using Infrastructure.Context;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class TransferService : ITransferService
{

    private readonly ITransferRepository _transferRepository;
    private readonly Bootcampp2Context _bootcampp2Context;

    public TransferService(ITransferRepository transferRepository, Bootcampp2Context context)
    {
        _transferRepository = transferRepository;
        _bootcampp2Context = context;
    }

    public async Task<TransferDTO> Create(TransferRequest request)
    {

        var senderAccount = await _bootcampp2Context.Accounts.FindAsync(request.SenderId);
        var receiverAccount = await _bootcampp2Context.Accounts.FindAsync(request.ReceiverId);
        switch (GetAccountValidationStatus(senderAccount, receiverAccount, request.Amount))
        {
            case AccountValidationsStatus.SenderNotFound:
                throw new Exception("senderId was not found");
            case AccountValidationsStatus.SenderNotActive:
                throw new Exception("Origin Account is not active");
            case AccountValidationsStatus.SenderBalanceInsufficient:
                throw new Exception("sender's account balance is insufficient.");
            case AccountValidationsStatus.Success:
                break;
            default:
                break;
        }
       
        return await _transferRepository.Create(request);

    }
    public AccountValidationsStatus GetAccountValidationStatus(Account senderAccount, Account receiverAccount, decimal amount)
    {
        if (senderAccount is null)
            return AccountValidationsStatus.SenderNotFound;

        if (senderAccount.IsDeleted)
            return AccountValidationsStatus.SenderNotActive;

        if (senderAccount.Balance < amount)
            return AccountValidationsStatus.SenderBalanceInsufficient;

        return AccountValidationsStatus.Success;
    }
}
