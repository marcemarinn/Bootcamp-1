using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ServicePaymentService : IServicePaymentRepository
{
    private readonly IServicePaymentRepository _servicePaymentRepository;

    public ServicePaymentService(ServicePaymentRepository servicePaymentRepository)
    {
        _servicePaymentRepository = servicePaymentRepository;
    }

    public Task<ServicePaymentDTO> Create(ServicePaymentRequest request)
    {

        return _servicePaymentRepository.Create(request);
    }
}

