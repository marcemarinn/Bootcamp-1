using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface IDepositService
{
    Task <DepositDTO> Create(DepositRequest request);

}


