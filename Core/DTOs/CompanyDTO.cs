using Core.Entities;

namespace Core.DTOs;

public class CompanyDTO
{
    public int Id { get; set; }

    public String? Name { get; set; }

    public String? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; } = null;


}
