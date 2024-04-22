using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface IDepositRepository
{
    Task<DepositDTO> Create(DepositRequest request);
}
