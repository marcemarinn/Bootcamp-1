using Core.DTOs;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface ICompanyService
{

    Task <CompanyDTO> Create(CreateCompanyRequest request);
}
