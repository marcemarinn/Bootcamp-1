using Core.Entities;
using Core.Models;
using Core.Requests;
using Mapster;

namespace Infrastructure.Mappings;

public class DepositConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<DepositRequest, Deposit>()
            .Map(dest => dest.AccountId, src => src.AccountId)
            .Map(dest => dest.BankId, src => src.BankId)
            .Map(dest => dest.OperationDate, src => src.OperationDate)
            .Map(dest => dest.Amount, src => src.Amount);

        config.NewConfig<Deposit, DepositDTO>()
          .Map(dest => dest.Id, src => src.Id)
          .Map(dest => dest.AccountId, src => src.AccountId)
          .Map(dest => dest.BankId, src => src.BankId)
          .Map(dest => dest.OperationDate, src => src.OperationDate)
          .Map(dest => dest.Amount, src => src.Amount);
    }
}
