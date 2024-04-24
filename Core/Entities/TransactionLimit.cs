using Core.Constants;

namespace Core.Entities;

public class TransactionLimit
{
    public int Id { get; set; }

    public TransactionType TransactionType { get; set; }

    public int OriginAccountId { get; set; }
    public int DestinationAccountId { get; set; }

    public Account AccountOrigin { get; set; }
    public Account AccountDestiny { get; set; }


    public decimal? TransactionalLimit { get; set; }


}
