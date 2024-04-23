using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface ITransactionService
{

    Task<TransactionDTO> Create(FilterTransactionRequest filter);
}
