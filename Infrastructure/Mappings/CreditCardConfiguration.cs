using Core.DTOs;
using Core.Entities;
using Core.Requests;
using Mapster;

namespace Infrastructure.Mappings;

public class CreditCardConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCreditCardModel, CreditCard>()
         .Map(dest => dest.ExpeditionDate, src => src.ExpeditionDate)
         .Map(dest => dest.Denomination, src => src.Denomination)
         .Map(dest => dest.CVV, src => src.CVV)
         .Map(dest => dest.CardStatus, src => src.CardStatus)
         .Map(dest => dest.DueDate, src => src.DueDate)
         .Map(dest => dest.CreditLimit, src => src.CreditLimit)
         .Map(dest => dest.AvailableBalance, src => src.AvailableBalance)
         .Map(dest => dest.CurrentDebt, src => src.CurrentDebt)
         .Map(dest => dest.InterestRate, src => src.InterestRate)
         .Map(dest => dest.CardNumber, src => src.CardNumber)
         .Map(dest => dest.CurrencyId, src => src.CurrencyId)
         .Map(dest => dest.CustomerId, src => src.CustomerId);


        config.NewConfig<CreditCard, CreditCardDTO>()
         .Map(dest => dest.Id, src => src.Id)
         .Map(dest => dest.ExpeditionDate, src => src.ExpeditionDate)
         .Map(dest => dest.Denomination, src => src.Denomination)
         .Map(dest => dest.CVV, src => src.CVV)
         .Map(dest => dest.CardStatus, src => src.CardStatus)
         .Map(dest => dest.DueDate, src => src.DueDate)
         .Map(dest => dest.CreditLimit, src => src.CreditLimit)
         .Map(dest => dest.AvailableBalance, src => src.AvailableBalance)
         .Map(dest => dest.CurrentDebt, src => src.CurrentDebt)
         .Map(dest => dest.InterestRate, src => src.InterestRate)
         .Map(dest => dest.CardNumber, src => src.CardNumber)
         .Map(dest => dest.CurrencyId, src => src.CurrencyId)
        .Map(dest => dest.CustomerId, src => src.CustomerId);

    }
}

