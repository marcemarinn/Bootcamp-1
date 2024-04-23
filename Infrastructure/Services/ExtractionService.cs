using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;

namespace Infrastructure.Services;

public class ExtractionService : IExtractionService
{

    private readonly IExtractionRepository _extractionRepository;

    public ExtractionService(IExtractionRepository extractionRepository)
    {
        _extractionRepository = extractionRepository;
    }

    public async Task<ExtractionDTO> Create(ExtractionRequest request)
    {
        return await _extractionRepository.Create(request);
    }
}
