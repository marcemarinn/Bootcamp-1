using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class ProductRequestDTO
{
    public int Id { get; set; }
    public string Description { get; set; }

    public DateTime AplicationDate { get; set; }

    public decimal Amount { get; set; }

    public int LoanTerm { get; set; }

    public RequestStatus Status { get; set; } = RequestStatus.EPending;

    public int CurrencyId { get; set; }


    public int ProductId { get; set; }


    public int CustomerId { get; set; }
}
