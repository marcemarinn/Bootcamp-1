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

    public async Task<List<MovementDTO>> GetFiltered(FilterMovementRequest filter, int accountId)
    {
        
            var query = _bootcampContext.Movements
                            .Include(m => m.Account)
                            .AsQueryable();

            query = query.Where(m => m.AccountId == accountId);




        if (filter.Year != null && filter.Month == null)
           throw new InvalidOperationException("You must specify the month along with the year.");


        if (filter.Month != null)
        {
            int month = filter.Month.Value;
            query = query.Where(x =>
                x.OperationalDate != null &&
                x.OperationalDate.Value.Month == month);
        }

        if (filter.Year != null)        
            query = query.Where(x =>
                x.OperationalDate != null &&
                x.OperationalDate.Value.Year == filter.Year);
        


        if (filter.StartDate.HasValue && filter.EndDate.HasValue)
            query = query.Where(m => 
            m.OperationalDate >= 
            filter.StartDate.Value && 
            m.OperationalDate <= 
            filter.EndDate.Value);
        

         if (filter.StartDate is not null)

            query = query.Where(m => 
            m.OperationalDate >= 
            filter.StartDate);


         if (filter.EndDate is not null)

            query = query.Where(m => 
            m.OperationalDate >= 
            filter.EndDate);


        if (!string.IsNullOrEmpty(filter.Description))
        {
            var formattedDescription = filter.Description.ToUpper(); 
            query = query.Where(m => m.Description.ToUpper() == formattedDescription);
        }

        var result = await query.ToListAsync();

           
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

