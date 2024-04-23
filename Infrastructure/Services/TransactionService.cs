using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;

namespace Infrastructure.Services;

public class TransactionService : ITransactionService
{

    private readonly ITransactionHistoryRepository _transactionHistoryRepository;

    public TransactionService(ITransactionHistoryRepository transactionHistoryRepository)
    {
        _transactionHistoryRepository = transactionHistoryRepository;
    }

    public Task<TransactionDTO> Create(FilterTransactionRequest filter)
    {
       return _transactionHistoryRepository.Create(filter);
    }
}
