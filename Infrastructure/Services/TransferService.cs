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

        if (senderAccount.Balance < amount)
            return AccountValidationsStatus.SenderBalanceInsufficient;

        return AccountValidationsStatus.Success;
    }



}
