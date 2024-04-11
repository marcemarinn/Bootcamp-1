using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;

namespace Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService (IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Task<AccountDTO> Add(CreateAccountModel model)
    {
        return _accountRepository.Add(model);
    }

    public Task <AccountDTO>  GetById(int id) 
    {
        return _accountRepository.GetById((id));
    }
}
