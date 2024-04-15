namespace Core.Requests
{
    public class CreateCurrentAccountRequest
    {
        public decimal? OperationalLimit { get; set; }
        public decimal? MonthAverage { get; set; }
        public decimal? Interest { get; set; }
    }
}