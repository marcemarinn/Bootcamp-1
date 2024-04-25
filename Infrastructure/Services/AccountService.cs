using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;
    private readonly BootcampContext _bootcampContext;

    public AccountService(BootcampContext bootcampContext, IAccountRepository repository)
    {
        _bootcampContext = bootcampContext;
            _repository = repository;

    }

    public AccountService(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<AccountDTO> Create(CreateAccountRequest request) 
        => await _repository.Create(request);

    public async Task<AccountDTO> GetById(int id) => await _repository.GetById(id);

    
}
