using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly Bootcampp2Context _context;

        public CurrencyRepository(Bootcampp2Context context)
        {
            _context = context;
        }

        public async Task<CurrencyDTO> Add(CreateCurrencyModel model)
        {
            var currencyToCreate = model.Adapt<Currency>();

            _context.Currency.Add(currencyToCreate);

            await _context.SaveChangesAsync();

            var currencyDTO = currencyToCreate.Adapt<CurrencyDTO>();

            return currencyDTO;
        }

        public async Task<List<CurrencyDTO>> GetFiltered(FilterCurrencyModel filter)
        {
            var query = _context.Currency.AsQueryable();

            if (filter.Id.HasValue && filter.Id > 0)
            {
                query = query.Where(x =>
                x.Id >= filter.Id);
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => 
                x.Name != null && x.Name.ToUpper() == filter.Name.ToUpper());
            }

            var result = await query.ToListAsync();

            return result.Select(currency => currency.Adapt<CurrencyDTO>()).ToList();


        }

       
        
    }
}
