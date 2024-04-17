using Core.DTOs;
using Core.Entities;
using Core.Requests;
using Mapster;
namespace Infrastructure.Mappings;

public class PromotionConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        { //Del Creation object hacia la entidad

            config.NewConfig<CreatePromotionRequest, Promotion>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Start, src => src.Start)
                .Map(dest => dest.End, src => src.End)
                
                .Map(dest => dest.DiscountPercentage, src => src.DiscountPercentage);



            //Entidad hacia el DTO


            config.NewConfig<Promotion, PromotionDTO>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                 .Map(dest => dest.Start, src => src.Start)

                .Map(dest => dest.End, src => src.End);


        }
    }


}