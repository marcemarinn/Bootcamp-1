using Core.Entities;
using Core.Models;
using Core.Requests;
using Mapster;
using MapsterMapper;

namespace Infrastructure.Mappings;

public class TransferConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TransferRequest, Transfer>()
             .Map(dest => dest.Amount, src => src.Amount)
             .Map(dest => dest.Description, src => src.Description)
             .Map(dest => dest.TransferDateTime, src => src.TransferDateTime)
             .Map(dest => dest.CurrencyId, src => src.CurrencyId)
             .Map(dest => dest.SenderId, src => src.SenderId)
             .Map(dest => dest.ReceiverId, src => src.ReceiverId);

        config.NewConfig<Transfer, TransferDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.TransferDateTime, src => src.TransferDateTime)
            .Map(dest => dest.CurrencyId, src => src.CurrencyId)
            .Map(dest => dest.SenderId, src => src.SenderId)
            .Map(dest => dest.ReceiverId, src => src.ReceiverId);
    }
}
