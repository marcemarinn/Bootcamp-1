using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TransactionRepository : ITransactionHistoryRepository
{

    private readonly BootcampContext _bootcampContext;

    public TransactionRepository(BootcampContext bootcampContext)
    {
        _bootcampContext = bootcampContext;
    }

    public async Task<List<TransactionDTO>> GetFilteredTransactions(FilterTransactionRequest filter)
    {
        var query = _bootcampContext.Transactions
            .Include(t => t.Account)
            .AsQueryable();

        // Filtro por cuenta
        if (filter.AccountId.HasValue)
        {
            query = query.Where(t => t.AccountId == filter.AccountId.Value);
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

        // Filtro por descripción
        if (!string.IsNullOrEmpty(filter.Description))
        {
            query = query.Where(t => t.Description.Contains(filter.Description));
        }

        // Ejecutar consulta y mapear a DTO
        var transactions = await query.ToListAsync();

        return transactions.Select(t => new TransactionDTO
        {
            Id = t.Id,
            AccountId = t.AccountId,
            Amount = t.Amount,
            OperationDate = t.OperationDate,
            Description = t.Description
            // Puedes añadir más propiedades según sea necesario
        }).ToList();
    }
