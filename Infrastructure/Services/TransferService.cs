using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;

namespace Infrastructure.Services;

public class TransferService : ITransferService
{

    private readonly ITransferRepository _transferRepository;
    private readonly BootcampContext _bootcampContext;

    public TransferService(ITransferRepository transferRepository, BootcampContext context)
    {
        _transferRepository = transferRepository;
        _bootcampContext = context;
    }

    public async Task<TransferDTO> Create(TransferRequest request)
    {

        var senderAccount = await _bootcampContext.Accounts.FindAsync(request.SenderId);
        var receiverAccount = await _bootcampContext.Accounts.FindAsync(request.ReceiverId);
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
