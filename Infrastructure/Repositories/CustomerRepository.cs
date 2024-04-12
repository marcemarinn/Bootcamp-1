using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Bootcampp2Context _context;

        public CustomerRepository(Bootcampp2Context context)
        {
            _context = context;
        }

        public async Task<List<CustomerDTO>> GetFiltered(FilterCustomersModel filter)
        {
            var query = _context.Customers
                .Include(c => c.Bank)
                .AsQueryable();

            if (filter.BirthYearFrom is not null)
            {
                query = query.Where(x =>
                    x.Birth != null &&
                    x.Birth.Value.Year >= filter.BirthYearFrom);
            }

            if (filter.BirthYearTo is not null)
            {
                query = query.Where(x =>
                    x.Birth != null &&
                    x.Birth.Value.Year <= filter.BirthYearTo);
            }

            var result = await query.ToListAsync();

            return result.Select(x => x.Adapt<CustomerDTO>()).ToList();
        }

        public async Task<CustomerDTO> Add(CreateCustomerModel model)
        {
            var customerToCreate = model.Adapt<Customer>();

            _context.Customers.Add(customerToCreate);

            await _context.SaveChangesAsync();

            var customerDTO = customerToCreate.Adapt<CustomerDTO>();

            return customerDTO;
        }
    }
}