using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface IExtractionRepository
{
    Task <ExtractionDTO> Create (ExtractionRequest request);

    public Task<decimal?> GetOperationalLimit(int accountId);
}
