using Core.Constants;
using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Requests;
using FluentValidation;
using Infrastructure.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Bootcampp2Context _context;

        public AccountRepository(Bootcampp2Context context)
        {
            _context = context;
        }
        private readonly IValidator<CreateCurrentAccountDTO> _currentAccountValidator;

        public async Task<AccountDTO> Add(CreateAccountModel model)
        {
            var accountToCreate = model.Adapt<Account>();

            _context.Accounts.Add(accountToCreate);

            await _context.SaveChangesAsync();

            var accountDTO = accountToCreate.Adapt<AccountDTO>();

            return accountDTO;
        }
        public async Task<CreateCurrentAccountDTO> AddCurrentAccount(CreateCurrentAccountModel model)
        {
            var currentAccountToCreate = model.Adapt<CurrentAccount>();

            _context.CurrentAccounts.Add(currentAccountToCreate);

            await _context.SaveChangesAsync();

            var currentAccountDTO = currentAccountToCreate.Adapt<CreateCurrentAccountDTO>();

            return currentAccountDTO;
        }

        public async Task<bool> Delete(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account is null)
            {
                throw new NotFoundException($"Account with id: {id} doest not exist");
            }

            account.IsDeleted = true;
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<AccountDTO>> GetById(int customerId)
        {
            var account = await _context.Customers.FindAsync(customerId);
            var query = _context.Accounts.AsQueryable();

            if (account is null)
            {
                throw new Exception("the customer account was not found");
            }

            var result = await query.ToListAsync();
            return result.Select(c => c.Adapt<AccountDTO>()).ToList();

        }


        public async Task<List<AccountDTO>> Filter(FilterAccountModel filter)
        {
            var query = _context.Accounts.AsQueryable();



            if (filter.Number is not null)
            {
                query = query.Where(a =>
                a.Number == filter.Number);

            }

            if (filter.Type is not null)
            {
                query = query.Where(a =>
                a.Type == filter.Type);
            }

            if (filter.CurrencyId is not null)
            {
                query = query.Where(a =>
                a.CurrencyId == filter.CurrencyId);
            }


            var result = await query.ToListAsync();

            return result.Select(c => c.Adapt<AccountDTO>()).ToList();


        }
    }
}
