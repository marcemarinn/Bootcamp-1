using Core.DTOs;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<AccountDTO> Add(CreateAccountModel model);
    Task<CreateCurrentAccountDTO> AddCurrentAccount(CreateCurrentAccountModel model);
    Task<List<AccountDTO>> GetById(int id);

    Task<bool> Delete(int id);

    Task <List<AccountDTO>> Filter(FilterAccountModel model);



}
