using Core.DTOs;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface ICompanyRepository
{

    Task<CompanyDTO> Create(CreateCompanyRequest request);
}
