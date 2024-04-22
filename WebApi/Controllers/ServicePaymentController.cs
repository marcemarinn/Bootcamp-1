using Core.Interfaces.Services;
using Core.Requests;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ServicePaymentController : BaseApiController
{

    private readonly IServicePaymentService _servicePaymentService;

    public ServicePaymentController(IServicePaymentService servicePaymentService)
    {
        _servicePaymentService = servicePaymentService;
    }

    [HttpPost]

    public async Task<IActionResult> Create([FromBody] ServicePaymentRequest request)
    {

      return Ok(await _servicePaymentService.Create(request));  
    }
}
