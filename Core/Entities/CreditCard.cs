using Core.Constants;

namespace Core.Entities;

public class CreditCard
{

    public int Id { get; set; }

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

    public int? CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public int? CurrencyId { get; set; }
    public virtual Currency Currency { get; set; }







}
