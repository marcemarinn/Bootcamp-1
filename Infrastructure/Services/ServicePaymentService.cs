using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;

namespace Infrastructure.Services;

public class ServicePaymentService : IServicePaymentService
{

    private readonly IServicePaymentRepository _repository;
    private readonly BootcampContext _bootcampContext;

    public ServicePaymentService(IServicePaymentRepository repository, BootcampContext bootcampContext)
    {
        _repository = repository;
        _bootcampContext = bootcampContext;
    }

    public async Task<ServicePaymentDTO> Create(ServicePaymentRequest request)
    {
        

        return await _repository.Create(request);
    }
}
