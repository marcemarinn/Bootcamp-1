using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface ITransactionHistoryService
{

    Task <List<TransactionHistoryDTO>> GetFilteredTransactions(FilterMovementRequest filter);
}
