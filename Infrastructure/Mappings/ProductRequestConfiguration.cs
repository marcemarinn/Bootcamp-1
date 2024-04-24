using Core.Entities;
using Core.Models;
using Core.Requests;
using Mapster;

namespace Infrastructure.Mappings;

public class ProductRequestConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProductRequestModel, ProductRequest>()
            .Map(dest => dest.AplicationDate, src => src.AplicationDate)
            .Map(dest => dest.ApprovalDate, src => src.ApprovalDate)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.LoanTerm, src => src.LoanTerm)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.ProductId, src => src.ProductId)
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.CurrencyId, src => src.CurrencyId);



        config.NewConfig<ProductRequest, ProductRequestDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.AplicationDate, src => src.AplicationDate)
            .Map(dest => dest.ApprovalDate, src => src.ApprovalDate)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.LoanTerm, src => src.LoanTerm)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.ProductId, src => src.ProductId)
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.CurrencyId, src => src.CurrencyId);
    }
}
