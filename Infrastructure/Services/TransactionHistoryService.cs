using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;

namespace Infrastructure.Services;

public class TransactionHistoryService : ITransactionHistoryService
{

    private readonly ITransactionHistoryRepository _transactionHistoryRepository;

    public TransactionHistoryService(ITransactionHistoryRepository transactionHistoryRepository)
    {
        _transactionHistoryRepository = transactionHistoryRepository;
    }

    public async Task<List<TransactionHistoryDTO>> GetFilteredTransactions(FilterMovementRequest filter)
    {
       return await _transactionHistoryRepository.GetFilteredTransactions(filter);
    }
}
