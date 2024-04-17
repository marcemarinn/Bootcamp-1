namespace Core.DTOs;

public class PromotionDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public List<int> CompanyIds { get; set; }

    public decimal DiscountPercentage { get; set; }
}
