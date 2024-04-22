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
        var serviceToCreate = request.Adapt<ServicePayment>();
        var serviceId = await _bootcampContext.ServicePayments.FindAsync(request.ServiceId);
        var accountId = await _bootcampContext.Accounts.FindAsync(request.AccountId);

        if (serviceId != null && accountId != null)
        {
            accountId.Balance -= request.Amount;

        }
        _bootcampContext.ServicePayments.Add(serviceToCreate);
        await _bootcampContext.SaveChangesAsync();

        return serviceToCreate.Adapt<ServicePaymentDTO>();



    }
}
