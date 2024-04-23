using Core.Models;
using Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories;

public interface ITransactionHistoryRepository
{
    Task<List<TransactionHistoryDTO>> GetFilteredTransactions(FilterMovementRequest filter);

}
