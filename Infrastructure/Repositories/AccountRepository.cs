using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Context;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly Bootcampp2Context _context;

    public AccountRepository (Bootcampp2Context context)
    {
        _context = context;
    }

    public async Task<AccountDTO> Add(CreateAccountModel model)
    {
            var accountToCreate = model.Adapt<Account>();  
            _context.Accounts.Add(accountToCreate);
            
            await _context.SaveChangesAsync();

        var accountDTO = accountToCreate.Adapt<AccountDTO>();
        return accountDTO;


    }

    public async Task<AccountDTO> GetById(int id)
    {
        var account = await _context.Accounts.FindAsync(id);

        if (account is null)
        {
            throw new Exception("account was not found");
        }
        else
        {

            var accountDTO = account.Adapt<AccountDTO>();

            return accountDTO;
        }
     
    }
}
