using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TransactionHistoryRepository : ITransactionHistoryRepository
{

    private readonly BootcampContext _bootcampContext;

    public TransactionHistoryRepository(BootcampContext bootcampContext)
    {
        _bootcampContext = bootcampContext;
    }

    public async Task<List<TransactionHistoryDTO>> GetFilteredTransactions(FilterMovementRequest filter)
    {
        var query = _bootcampContext.TransactionHistories
            .Include(t => t.Account)
            .AsQueryable();

        // Filtro por cuenta
        if (filter.AccountId != 0)
        {
            query = query.Where
                (t => t.AccountId == filter.AccountId);
        }

        // Filtro por mes/año
        if (filter.Month.HasValue && filter.Year.HasValue)
        {
            var startDate = new DateTime(filter.Year.Value, filter.Month.Value, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            query = query.Where(t => t.OperationDate >= startDate && t.OperationDate <= endDate);
        }

        // Filtro por rango de fechas
        if (filter.StartDate.HasValue && filter.EndDate.HasValue)
        {
            query = query.Where(t => t.OperationDate >= filter.StartDate && t.OperationDate <= filter.EndDate);
        }


        // Ejecutar consulta y mapear a DTO
        var transactions = await query.ToListAsync();

        return transactions.Select(t => new TransactionHistoryDTO
        {
            Id = t.Id,
            AccountId = t.AccountId,
            Amount = t.Amount,
            OperationDate = t.OperationDate,
            Description = t.Description
            // Puedes añadir más propiedades según sea necesario
        }).ToList();
    }
}
