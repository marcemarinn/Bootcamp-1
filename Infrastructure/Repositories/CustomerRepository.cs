using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly BootcampContext _context;

    public CustomerRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<List<CustomerDTO>> GetFiltered(FilterCustomersModel filter)
    {
        var query = _context.Customers
            .Include(c => c.Bank)
            .AsQueryable();

        if(filter.BirthYearFrom is not null)
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

        return result.Select(x => new CustomerDTO
        {
            Id = x.Id,
            Name = x.Name,
            Lastname = x.Lastname,
            DocumentNumber = x.DocumentNumber,
            Address = x.Address,
            Mail = x.Mail,
            Phone = x.Phone,
            CustomerStatus = nameof(x.CustomerStatus),
            Birth = x.Birth,
            Bank = new BankDTO
            {
                Id = x.Bank.Id,
                Name = x.Bank.Name,
                Phone = x.Bank.Phone,
                Mail = x.Bank.Mail,
                Address = x.Bank.Address
            }
        }).ToList();
    }

    public async Task<List<CustomerDTO>> GetAll()
    {
        var customers = await _context.Customers.ToListAsync();

        var customerDTO = customers.Adapt<List<CustomerDTO>>();

        return customerDTO;
    }
}
