using Core.Constants;

namespace Core.Entities;

public class ProductRequest
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public DateTime AplicationDate { get; set; }

    public DateTime ApprovalDate { get; set; }

    public decimal Amount { get; set; }

    public int LoanTerm { get; set; }

    public RequestStatus Status { get; set; }

    public int CurrencyId { get; set; }

    public Currency Currency { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

}
