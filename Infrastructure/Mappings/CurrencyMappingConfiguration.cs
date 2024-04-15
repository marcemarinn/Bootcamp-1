using Core.Entities;
using Core.Models;
using Mapster;

namespace Infrastructure.Mappings;

public class CurrencyMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Currency, CurrencyDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name);
    }
}
