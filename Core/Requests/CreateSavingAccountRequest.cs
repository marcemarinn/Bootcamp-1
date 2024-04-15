using Core.Constants;

namespace Core.Requests;

public class CreateSavingAccountRequest
{
    public SavingType SavingType { get; set; } = SavingType.Insight;


}
