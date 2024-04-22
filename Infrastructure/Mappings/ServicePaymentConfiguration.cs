using Core.DTOs;
using Core.Entities;
using Core.Requests;
using Mapster;

namespace Infrastructure.Mappings;

public class ServicePaymentConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ServicePaymentRequest, ServicePayment>()
         .Map(dest => dest.Amount, src => src.Amount)
         .Map(dest => dest.AccountId, src => src.AccountId)
         .Map(dest => dest.Description, src => src.Description)
         .Map(dest => dest.DocumentNumber, src => src.DocumentNumber);

            config.NewConfig<ServicePaymentDTO, ServicePayment >()
         .Map(dest => dest.Id, src => src.Id)
         .Map(dest => dest.Amount, src => src.Amount)
         .Map(dest => dest.AccountId, src => src.AccountId)
         .Map(dest => dest.Description, src => src.Description)
         .Map(dest => dest.DocumentNumber, src => src.DocumentNumber);

    }
}
