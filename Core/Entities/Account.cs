using Core.Constants;

namespace Core.Entities;

public class Account
{
    public int Id { get; set; }
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public AccountType Type { get; set; } = AccountType.Current;
    public decimal Balance { get; set; }
    public AccountStatus Status { get; set; } = AccountStatus.Active;
    public bool IsDeleted { get; set; }

    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public SavingAccount? SavingAccount { get; set; }
    public CurrentAccount? CurrentAccount { get; set; }

    public virtual ICollection<Transfer> TransfersReceived { get; set; } = new List<Transfer>();
    public virtual ICollection<Transfer> TransfersSent { get; set; } = new List<Transfer>();
    public virtual ICollection<Movement> Movements { get; set; } = new List<Movement>();
    public virtual ICollection<ServicePayment> PaymentServices { get; set; } = new List<ServicePayment>();
    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
    public ICollection<TransactionLimit> TransactionLimitsOrigin { get; set; } = new List<TransactionLimit>();
    public ICollection<TransactionLimit> TransactionLimitsDestiny { get; set; } = new List<TransactionLimit>();

    public virtual ICollection<Extraction> Extractions { get; set; } = new List<Extraction>();
    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();

}
