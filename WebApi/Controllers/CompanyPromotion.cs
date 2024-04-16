using Core.Interfaces.Services;
using Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CompanyPromotion : BaseApiController
{
    private readonly ICompanyPromotionService _companyPromotionService;

    public CompanyPromotion(ICompanyPromotionService companyPromotionService)
    {
        _companyPromotionService = companyPromotionService;
    }

    [HttpPost]

    public async Task<IActionResult> Create(CreateCompanyPromotionRequest request)
    {
        return Ok(await _companyPromotionService.Create(request));
    }


}
