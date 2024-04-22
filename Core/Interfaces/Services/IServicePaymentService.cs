using Core.DTOs;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface IServicePaymentService
{
    Task <ServicePaymentDTO> Create(ServicePaymentRequest request); 

}
