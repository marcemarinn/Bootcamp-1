namespace Core.Entities;

public class Promotion
{

    public int Id { get; set; }
    public string Name { get; set; }
    public TimeSpan Duration { get; set; }
    public decimal DiscountPercentage { get; set; }


    public ICollection<CompanyPromotion> CompanyPromotion { get; set; } = new List<CompanyPromotion>();




}
