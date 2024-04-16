using Core.DTOs;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface ICompanyPromotionService
{
    Task<CompanyPromotionDTO> Create(CreateCompanyPromotionRequest request);


}
