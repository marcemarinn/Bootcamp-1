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

    public async Task<AccountDTO> Add(CreateAccountModel model)
    {
        var evaluaCuenta = EvaluarCuenta(model);
        var accountDTO = new AccountDTO();

        if (string.IsNullOrEmpty(evaluaCuenta))
        {
            accountDTO = await _accountRepository.Add(model);
            switch (model.Type)
            {
                case Core.Constants.AccountType.Current:
                    int accountId = accountDTO.Id;
                    model.CreateCurrentAccountDTO.AccountId = accountId;
                     _accountRepository.AddCurrentAccount(model.CreateCurrentAccountDTO);
                    break;
                case Core.Constants.AccountType.Saving:
                    break;
            }
        }

        return accountDTO;
    }

    private string EvaluarCuenta(CreateAccountModel model)
    {
        switch (model.Type)
        {
            case Core.Constants.AccountType.Current:

                if (model.CreateCurrentAccountDTO?.OperationalLimit == 0)
                    return "requerido";

                break;
            case Core.Constants.AccountType.Saving:
                if (model.CreateCurrentAccountDTO?.OperationalLimit == 0)
                    return "requerido";
                break;           
        }
        return string.Empty;
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
