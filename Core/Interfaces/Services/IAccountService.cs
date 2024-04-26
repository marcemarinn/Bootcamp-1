using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface IAccountService
{
    Task<int> Create(CreateAccountRequest request);
    Task<AccountDTO> GetById(int id);

    Task<List<AccountDTO>> GetAll();

}
