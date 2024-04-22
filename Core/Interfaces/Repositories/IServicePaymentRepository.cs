using Core.DTOs;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface IServicePaymentRepository
{
    Task <ServicePaymentDTO> Create(ServicePaymentRequest request); 

}
