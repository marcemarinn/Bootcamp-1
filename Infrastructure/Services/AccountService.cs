using Core.Constants;
using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests;

namespace Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    
    public async Task<AccountDTO> Create(CreateAccountRequest request)
    {
        
         return await _accountRepository.Create(request);

    }

   
    public Task<List<AccountDTO>> GetById(int id)
    {
        return _accountRepository.GetById((id));
    }

    public Task<bool> Delete(int id)
    {
        return _accountRepository.Delete(id);
    }

    public Task<List<AccountDTO>> Filter(FilterAccountModel model)
    {
        return _accountRepository.Filter(model);
    }


}
