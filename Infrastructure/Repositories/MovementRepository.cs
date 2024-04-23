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
           .Include(c => c.Account)
           .AsQueryable();

        if (filter.AccountId != 0)
        {
            query = query.Where(x =>
                x.AccountId != null &&
                x.AccountId >= filter.AccountId);
        }



        var result = await query.ToListAsync();

        return result.Select(x => new MovementDTO
        {
            Id = x.Id,
            Description = x.Description,
            OperationalDate = x.OperationalDate,
            AccountId = x.AccountId,
            TransactionType = x.TransactionType,
            Amount = x.Amount
        }).ToList();
    }
}