using Core.DTOs;
using Core.Interfaces.Services;
using Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PromotionController : BaseApiController
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpPost]
        public async Task<PromotionDTO> Create(CreatePromotionRequest model)
        {
            return await _promotionService.Create(model);
        }

    }
}
