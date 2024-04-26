using Core.Constants;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ExtractionService : IExtractionService
{

    private readonly IExtractionRepository _extractionRepository;

    private readonly BootcampContext _bootcampContext;

    public ExtractionService(IExtractionRepository extractionRepository, BootcampContext bootcampContext)
    {
        _extractionRepository = extractionRepository;
        _bootcampContext = bootcampContext;
    }

    public async Task<ExtractionDTO> Create(ExtractionRequest request)
    {
        var account = await _bootcampContext.Accounts
       .Where(a => a.Id == request.AccountId)
        .FirstAsync();

        
        if (account == null)
            throw new NotFoundException("The account does not exist");


        if (account.Balance < request.Amount )
            throw new NotFoundException("The account balance is insufficient ");

        //var operationalLimit = await _extractionRepository.GetOperationalLimit(request.AccountId);

        //if (operationalLimit.HasValue && request.Amount > operationalLimit.Value)
        //{
        //    throw new InvalidOperationException("El monto de extracción supera el límite operacional");
        //}

        account.Balance -= request.Amount;

        var extractionToCreate = new Extraction
        {
            AccountId = request.AccountId,
            Amount = request.Amount
        };

        var movementToCreate = new Movement
        {
            AccountId = request.AccountId,
            Amount = request.Amount,
            OperationalDate = request.OperationalDate,
            TransactionType = TransactionType.EExtraction
        };

        _bootcampContext.Extractions.Add(extractionToCreate);
        _bootcampContext.Movements.Add(movementToCreate);

        await _bootcampContext.SaveChangesAsync();

        return extractionToCreate.Adapt<ExtractionDTO>();
    }
    

}
