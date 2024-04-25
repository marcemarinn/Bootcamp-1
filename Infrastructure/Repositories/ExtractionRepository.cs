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

public class ExtractionRepository : IExtractionRepository
{
    private readonly BootcampContext _bootcampContext;

    public ExtractionRepository(BootcampContext bootcampContext)
    {
        _bootcampContext = bootcampContext;
    }

    public Task<ExtractionDTO> Create(ExtractionRequest request)
    {
        throw new NotImplementedException();
    }
    

    public async Task<decimal?> GetOperationalLimit(int accountId)
    {
       
        var account = await _bootcampContext.Accounts
       .Where(a => a.Id == accountId)
        .FirstAsync();

        var operationalLimit = await _bootcampContext.CurrentAccounts
             .Where(t => t.AccountId == account.Id)
             .Select(t => t.OperationalLimit)
             .FirstOrDefaultAsync();

        return operationalLimit;
    }

    
}
