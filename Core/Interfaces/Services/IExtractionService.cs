using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface IExtractionService
{
    Task<ExtractionDTO> Create(ExtractionRequest request);

}
