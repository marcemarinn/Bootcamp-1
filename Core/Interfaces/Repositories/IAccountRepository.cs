using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<int> Create(CreateAccountRequest request);
    Task<AccountDTO> GetById(int id);
    Task<List<AccountDTO>> GetAll();


}
