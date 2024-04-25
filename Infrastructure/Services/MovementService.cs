using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;

namespace Infrastructure.Services;

public class MovementService : IMovementService
{
    private readonly IMovementRepository _repository;

    public MovementService(IMovementRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MovementDTO>> GetFiltered(FilterMovementRequest filter,int accountId)
    {
        return await _repository.GetFiltered(filter,accountId);
    }
}
