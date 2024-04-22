using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class DepositController : BaseApiController
    {

        private readonly IDepositService _depositService;

        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepositRequest request)
        {
            return Ok(_depositService.Create(request));
        }
    }
}
