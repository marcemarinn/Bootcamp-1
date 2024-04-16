using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests;

namespace Infrastructure.Services;

public class CompanyPromotionService : ICompanyPromotionService
{
    private readonly ICompanyPromotionRepository _companyPromotionRepository;

    public CompanyPromotionService(ICompanyPromotionRepository companyPromotionRepository)
    {
        _companyPromotionRepository = companyPromotionRepository;
    }

    public async Task<CompanyPromotionDTO> Create(CreateCompanyPromotionRequest request)
    {
        return await _companyPromotionRepository.Create(request);


    }


}