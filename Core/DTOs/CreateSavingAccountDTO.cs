using Core.Constants;

namespace Core.DTOs;

public class CreateSavingAccountDTO
{

    public SavingType SavingType { get; set; } = SavingType.Insight;
    public string HolderName { get; set; } = string.Empty;


    //public Account Account { get; set; } = null!;

}
