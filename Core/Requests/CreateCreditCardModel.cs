using Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Requests
{
    public class CreateCreditCardModel
    {
        public string? Denomination { get; set; }

        public DateTime ExpeditionDate { get; set; }

        public DateTime DueDate { get; set; }

        public string? CardNumber { get; set; }

        public string? CVV { get; set; }

        public CardStatus CardStatus { get; set; }

        public decimal CreditLimit { get; set; }

        public decimal AvailableBalance { get; set; }

        public decimal CurrentDebt { get; set; }

        public decimal InterestRate { get; set; }

        public int CustomerId { get; set; }

        public int CurrencyId { get; set; }


    }
}
