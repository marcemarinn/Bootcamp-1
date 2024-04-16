using System.Globalization;

namespace Core.Entities;

public class CompanyPromotion
{

    public int CompanyId { get; set; }
    public int PromotionId { get; set; }

    public Promotion Promotion { get; set; }
    public Company Company { get; set; }

    





}
