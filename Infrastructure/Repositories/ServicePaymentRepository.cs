using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;

namespace Infrastructure.Repositories;

public class ServicePaymentRepository : IServicePaymentRepository
{
    private readonly BootcampContext _bootcampContext;

    public ServicePaymentRepository(BootcampContext bootcampContext)
    {
        _bootcampContext = bootcampContext;
    }

    public async Task<ServicePaymentDTO> Create(ServicePaymentRequest request)
    {
        
        var servicePaymentToCreate = request.Adapt<ServicePayment>();

       
        var service = await _bootcampContext.Services.FindAsync(request.ServiceId);
        var account = await _bootcampContext.Accounts.FindAsync(request.AccountId);

       
        if (service == null || account == null)
        {
            
            throw new Exception("The corresponding service or account was not found.");
        }

        
        decimal newBalance = account.Balance - request.Amount;

        
        if (newBalance < 0)
        {
            throw new Exception("There are insufficient funds in the account to complete this transaction.");
        }

        account.Balance = newBalance;

        var movementToCreate = new Movement
        {
            AccountId = request.AccountId,
            Amount = request.Amount,
            OperationalDate = request.OperationalDate,
            TransactionType = TransactionType.EServicePayment
        };

        _bootcampContext.Movements.Add(movementToCreate);
        _bootcampContext.Accounts.Update(account);
        _bootcampContext.ServicePayments.Add(servicePaymentToCreate);


        await _bootcampContext.SaveChangesAsync();

       
        return servicePaymentToCreate.Adapt<ServicePaymentDTO>();

    }
}

