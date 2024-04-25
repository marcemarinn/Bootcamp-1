using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface IMovementRepository
{
    Task<List<MovementDTO>> GetFiltered(FilterMovementRequest filter, int accountId);


}
