namespace Core.Entities;

public class Promotion
{

    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int DiscountPercentage { get; set; }


    public ICollection<CompanyPromotion> CompanyPromotion { get; set; } = new List<CompanyPromotion>();




}
