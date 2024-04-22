using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Context;
using Mapster;

namespace Infrastructure.Repositories;

public class ServicePaymentRepository : IServicePaymentRepository
{
    private readonly Bootcampp2Context _bootcampp2Context;

    public ServicePaymentRepository(Bootcampp2Context bootcampp2Context)
    {
        _bootcampp2Context = bootcampp2Context;
    }

    public async Task<ServicePaymentDTO> Create(ServicePaymentRequest request)
    {
        var servicePaymentToCreate= request.Adapt<ServicePayment>();

        _bootcampp2Context.ServicePayments.Add(servicePaymentToCreate);

        var senderAccount = await _bootcampp2Context.Accounts.FindAsync(request.AccountId);
       
        
        senderAccount.Balance -= request.Amount;
        await _bootcampp2Context.SaveChangesAsync();

        return servicePaymentToCreate.Adapt<ServicePaymentDTO>();
    }
}
