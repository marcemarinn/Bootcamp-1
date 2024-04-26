using Core.Constants;
using Core.Entities;
using Core.Exceptions;
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
       
        var bankId = await _bootcampContext.Banks.FindAsync(request.BankId);
        var accountId = await _bootcampContext.Accounts.FindAsync(request.AccountId);

        if (accountId == null || bankId == null)
        {
            throw new NotFoundException("The specified account or bank does not exist.");
        }

        if (accountId.Balance < 0)
        {
            throw new NotFoundException("The specified account does have enough balance");
        }

        DateTime dateStartMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        DateTime dateEndMonth = dateStartMonth.AddMonths(1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);

        decimal totalMovementsInMonth = await _bootcampContext.Movements
            .Where(m => m.OperationalDate >= dateStartMonth && m.OperationalDate <= dateEndMonth)
            .SumAsync(m => m.Amount);

        decimal newTotalMovementsInMonth = totalMovementsInMonth + request.Amount;

        var operationalLimit = await _bootcampContext.CurrentAccounts
            .Where(t => t.AccountId == accountId.Id)
            .Select(t => t.OperationalLimit)
            .FirstOrDefaultAsync();

        if (newTotalMovementsInMonth > operationalLimit)
        {
            throw new NotFoundException("The account has reached the operational limit");
        }

        var depositToCreate = request.Adapt<Deposit>();

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
