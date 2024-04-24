using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ProductRequestController : BaseApiController
{
    private readonly IProductRequestService _productRequestService;

    public ProductRequestController(IProductRequestService productRequestService)
    {
        _productRequestService = productRequestService;
    }

    [HttpPost]

    public async Task<IActionResult> Create([FromBody] ProductRequestModel request)
    {

        return Ok(await _productRequestService.Create(request));
    }
}
