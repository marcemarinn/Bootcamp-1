namespace Core.Requests;

public class CreateCompanyPromotionRequest
{

    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int CompanyId { get; set; }
    public int PromotionId { get; set; }
}
