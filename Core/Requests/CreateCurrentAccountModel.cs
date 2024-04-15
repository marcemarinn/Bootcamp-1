using Core.Entities;

namespace Core.Requests;

public class CreateCurrentAccountModel
{
    public decimal? OperationalLimit { get; set; }
    public decimal? MonthAverage { get; set; }
    public decimal? Interest { get; set; }
    public int AccountId { get; set; }
    //public Account Account { get; set; } = null!;
}


