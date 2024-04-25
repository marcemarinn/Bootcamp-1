using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface IMovementService
{
    Task<List<MovementDTO>> GetFiltered(FilterMovementRequest filter);


}
