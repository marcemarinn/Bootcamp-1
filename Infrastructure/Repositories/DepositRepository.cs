using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;

namespace Infrastructure.Repositories;

public class DepositRepository : IDepositRepository
{

    private readonly BootcampContext _bootcampContext;

    public DepositRepository(BootcampContext bootcampContext)
    {
        _bootcampContext = bootcampContext;
    }

    public async Task<DepositDTO> Create(DepositRequest request)
    {

        var bankId = await _bootcampContext.Banks.FindAsync(request.BankId);
        var accountId = await _bootcampContext.Accounts.FindAsync(request.AccountId);

        if (accountId == null || bankId == null)
        {
            
            throw new ArgumentException("La cuenta o el banco especificados no existen.");
        }

       

        var depositToCreate = request.Adapt<Deposit>();

        depositToCreate.Account = accountId;
        depositToCreate.Bank = bankId;

        accountId.Balance += request.Amount;

        _bootcampContext.Deposits.Add(depositToCreate);
        await _bootcampContext.SaveChangesAsync();

        return depositToCreate.Adapt<DepositDTO>();


    }
}
