using Core.DTOs;
using Core.Entities;
using Core.Requests;
using Mapster;

namespace Infrastructure.Mappings;

public class CompanyConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCompanyRequest, Company>()
             .Map(dest => dest.Name, src => src.Name)
             .Map(dest => dest.Email, src => src.Email)
             .Map(dest => dest.PhoneNumber,src => src.PhoneNumber)
             .Map(dest => dest.Address, src => src.Address);


        config.NewConfig<Company, CompanyDTO>()
             .Map(dest => dest.Id, src => src.Id)
             .Map(dest => dest.Name, src => src.Name)
             .Map(dest => dest.Email, src => src.Email)
             .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
             .Map(dest => dest.Address, src => src.Address);
    }
}
