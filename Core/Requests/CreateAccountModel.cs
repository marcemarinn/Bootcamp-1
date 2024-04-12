using Core.Constants;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Requests
{
    public class CreateAccountModel
    {
        public string Holder { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public AccountType Type { get; set; } = AccountType.Current;
        public AccountStatus Status { get; set; } = AccountStatus.Active;
        public decimal Balance { get; set; }

        public int CurrencyId { get; set; }
        //public Currency Currency { get; set; } = null!;

        public int CustomerId { get; set; }
        //public Customer Customer { get; set; } = null!;



        public CreateSavingAccountDTO? CreateSavingAccountDTO { get; set; }
        public CreateCurrentAccountDTO? CreateCurrentAccountDTO { get; set; }
    }
}
