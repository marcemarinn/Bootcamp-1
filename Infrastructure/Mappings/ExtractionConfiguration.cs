using Core.Entities;
using Core.Models;
using Core.Requests;
using Mapster;

namespace Infrastructure.Mappings;

public class ExtractionConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ExtractionRequest, Extraction>()
         .Map(dest => dest.Amount, src => src.Amount)
         .Map(dest => dest.AccountId, src => src.AccountId);

        config.NewConfig<Extraction, ExtractionDTO>()
        .Map(dest => dest.Id, src => src.Id)
        .Map(dest => dest.Amount, src => src.Amount)
        .Map(dest => dest.AccountId, src => src.AccountId);



    }
}