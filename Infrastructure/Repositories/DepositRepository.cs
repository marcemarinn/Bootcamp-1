using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

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

        var bankId = await _bootcampContext.Banks
            .FindAsync(request.BankId);

        var accountId = await _bootcampContext.Accounts
            .FindAsync(request.AccountId);

        var transactionType = await _bootcampContext.Accounts
            .Where(c => c.Type == 0)
            .Select(c => c.Type)
            .FirstOrDefaultAsync();

        if (accountId == null || bankId == null)
        {
            
            throw new ArgumentException("The specified account or bank does not exist.");
        }
       
        var depositToCreate = request.Adapt<Deposit>();

        depositToCreate.Account = accountId;
        depositToCreate.Bank = bankId;

        accountId.Balance += request.Amount;

        var movementToCreate = new Movement
        {
            AccountId = request.AccountId,
            Amount = request.Amount,
            OperationalDate = request.OperationDate,
            TransactionType = TransactionType.EDeposit
        };


        _bootcampContext.Movements.Add(movementToCreate);
        _bootcampContext.Deposits.Add(depositToCreate);
        await _bootcampContext.SaveChangesAsync();

        return depositToCreate.Adapt<DepositDTO>();


    }
}
