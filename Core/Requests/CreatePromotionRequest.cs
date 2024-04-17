namespace Core.Requests;

public class CreatePromotionRequest
{
  
    public string Name { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public List<int> CompanyIds { get; set; }

    public decimal DiscountPercentage { get; set; }
}