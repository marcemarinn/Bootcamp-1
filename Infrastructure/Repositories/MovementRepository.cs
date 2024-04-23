using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class MovementRepository : IMovementRepository
{

    public readonly BootcampContext _bootcampContext;

    public MovementRepository(BootcampContext bootcampContext)
    {
        _bootcampContext = bootcampContext;
    }

    public async Task<List<MovementDTO>> GetFiltered(FilterMovementRequest filter)
    {
        
            var query = _bootcampContext.Movements
                            .Include(m => m.Account)
                            .AsQueryable();

            // Filtro por AccountId si se proporciona en la solicitud
            if (filter.AccountId != 0)
            {
                query = query.Where(m => m.AccountId == filter.AccountId);
            }

            // Filtro por mes/año si se proporciona en la solicitud
            if (filter.Month.HasValue && filter.Year.HasValue)
            {
                var firstDayOfMonth = new DateTime(filter.Year.Value, filter.Month.Value, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                query = query.Where(m => m.OperationalDate >= firstDayOfMonth && m.OperationalDate <= lastDayOfMonth);
            }
            else if (filter.Month.HasValue && !filter.Year.HasValue)
            {
                throw new ArgumentException("Se debe especificar el año junto con el mes.");
            }

        // Filtro por rango de fechas si se proporciona en la solicitud
        if (filter.StartDate.HasValue && filter.EndDate.HasValue)
        {
            query = query.Where(m
                => m.OperationalDate >=
                filter.StartDate.Value
                && m.OperationalDate <= filter.EndDate.Value);
        }

        
            if (!string.IsNullOrEmpty(filter.Description))
            {
                query = query.Where(m => m.Description.Contains(filter.Description));
            }

            // Ejecutar la consulta y obtener los resultados
            var result = await query.ToListAsync();

            // Mapear los resultados a DTOs y devolver la lista
            return result.Select(m => new MovementDTO
            {
                Id = m.Id,
                Description = m.Description,
                OperationalDate = m.OperationalDate,
                AccountId = m.AccountId,
                TransactionType = m.TransactionType,
                Amount = m.Amount
            }).ToList();
        }
    }

