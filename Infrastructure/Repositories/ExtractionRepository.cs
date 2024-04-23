using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;

namespace Infrastructure.Repositories;

public class ExtractionRepository : IExtractionRepository
{
    private readonly BootcampContext _bootcampContext;

    public ExtractionRepository(BootcampContext bootcampContext)
    {
        _bootcampContext = bootcampContext;
    }

    public async Task<ExtractionDTO> Create(ExtractionRequest request)
    {
        var extractionToCreate = request.Adapt<Extraction>();

        var accountId = await _bootcampContext.Accounts.FindAsync(request.AccountId);
        var bankId = await _bootcampContext.Banks.FindAsync(request.BankId);

        

        if (accountId == null || bankId == null)
        {

            throw new ArgumentException("La cuenta o el banco especificados no existen.");
        }

        accountId.Balance -= request.Amount;
        _bootcampContext.Extraction.Add(extractionToCreate);
        await _bootcampContext.SaveChangesAsync();
        return extractionToCreate.Adapt<ExtractionDTO>();
    }
}
