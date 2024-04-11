using Core.Entities;
using Core.Models;
using Core.Requests;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{
    public class AccountConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateAccountModel, Account>()
            .Map(dest => dest.Holder, src => src.Holder)
            .Map(dest => dest.Number, src => src.Number)
            .Map(dest => dest.Status, src => src.Status)
            /*.Map(dest => dest.SavingAccount, src => src.SavingAccount)
            .Map(dest => dest.CurrentAccount, src => src.CurrentAccount)*/
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.CurrencyId, src => src.CurrencyId)
            .Map(dest => dest.Balance, src => src.Balance)
            .Map(dest => dest.Type, src => src.Type);

            config.NewConfig<Account, AccountDTO>()
                .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Holder, src => src.Holder)
            .Map(dest => dest.Number, src => src.Number)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.Balance, src => src.Balance)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.CurrencyId, src => src.CurrencyId)
            .Map(dest => dest.CustomerId, src => src.CustomerId);
           /* .Map(dest => dest.SavingAccount, src => src.SavingAccount)
            .Map(dest => dest.CurrentAccount, src => src.CurrentAccount);*/





        }
    }
}
