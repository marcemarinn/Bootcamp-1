using Core.Entities;

namespace Core.Requests;

public class CreateCompanyRequest
{
    public String? Name { get; set; }

    public String? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; } = null;


}
