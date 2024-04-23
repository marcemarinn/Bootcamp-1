using Core.Constants;
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
        var accountId = await _bootcampContext.Accounts.FindAsync(request.AccountId);

        if (accountId == null )
        {
            throw new ArgumentException("La cuenta no existe");
        }

        if (accountId.Balance < request.Amount)
        {
            throw new InvalidOperationException("El saldo de la cuenta es insuficiente para realizar la extracción.");
        }

        accountId.Balance -= request.Amount;

        var extractionToCreate = new Extraction
        {
            AccountId = request.AccountId,
            Amount = request.Amount,
           
        };

        var movementToCreate = new Movement
        {
            AccountId = request.AccountId,
            Amount = request.Amount,
            OperationalDate = request.OperationalDate,
            TransactionType = TransactionType.Extraction
        };

        _bootcampContext.Extractions.Add(extractionToCreate);
        _bootcampContext.Movements.Add(movementToCreate);

        await _bootcampContext.SaveChangesAsync();

        return extractionToCreate.Adapt<ExtractionDTO>();
    }
}
