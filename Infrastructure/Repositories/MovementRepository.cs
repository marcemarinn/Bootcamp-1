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


        if (filter.AccountId == null) { 
        {
            throw new ArgumentException("Account ID is required.");
        }

        if (filter.AccountId > 0)
        {
            query = query.Where(m => m
        .AccountId == filter.AccountId);

        }
        }

            if (filter.Year != null && filter.Month == null )
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


            if (filter.Description != null )
            {
                var formattedDescription = filter.Description.ToLower();
                query = query.Where(m => !string.IsNullOrEmpty(m.Description) && m.Description.ToLower() == formattedDescription);
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

