using Core.DTOs;
using Core.Entities;
using Core.Requests;
using Mapster;

namespace Infrastructure.Mappings;

public class CompanyPromotionMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCompanyPromotionRequest, CompanyPromotion>()
               .Map(dest => dest.CompanyId, src => src.CompanyId)
               .Map(dest => dest.PromotionId, src => src.PromotionId);

        config.NewConfig<CompanyPromotion, CompanyPromotionDTO>()
              .Map(dest => dest.CompanyId, src => src.CompanyId)
              .Map(dest => dest.PromotionId, src => src.PromotionId);


    }
}
