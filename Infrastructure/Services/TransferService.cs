using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class TransferService : ITransferService
{

    private readonly ITransferRepository _transferRepository;

    public TransferService(ITransferRepository transferRepository)
    {
        _transferRepository = transferRepository;
    }

    public Task<TransferDTO> Create(TransferRequest request)
    {
        var senderAccount =  _transferRepository.FindAsync(request.SenderId);
        var receiverAccount =  _transferRepository.FyndAsync(request.ReceiverId);

        if (senderAccount == null || receiverAccount == null ||
            senderAccount.AccountType != receiverAccount.AccountType ||
            senderAccount.CurrencyId != receiverAccount.CurrencyId ||
            request.Amount <= 0 || request.Amount > senderAccount.Balance ||
            !senderAccount.IsActive)
        {
            throw new ArgumentException("Transferencia no válida.");
        }

        var senderOriginalBalance = senderAccount.Balance;
        var receiverOriginalBalance = receiverAccount.Balance;

        senderAccount.Balance -= request.Amount;
        receiverAccount.Balance += request.Amount;

        var senderMovement = new Transfer
        {
            SenderId = senderAccount.Id,
            Amount = -request.Amount,
            TransferDateTime = DateTime.UtcNow,
            Description = "Transferencia enviada a " + receiverAccount.AccountNumber
        };

        var receiverMovement = new Transfer
        {
            ReceiverId = receiverAccount.Id,
            Amount = request.Amount,
            TransferDateTime = DateTime.UtcNow,
            Description = "Transferencia recibida de " + senderAccount.AccountNumber
        };

        var updateAccountsResult = await _repository.UpdateAccountsAsync(senderAccount, receiverAccount);
        var addMovementsResult = await _repository.AddMovementsAsync(senderMovement, receiverMovement);

    }
}
