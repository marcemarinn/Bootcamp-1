using Core.Interfaces.Services;
using Core.DTOs;
using Core.Requests;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CustomerController : BaseApiController
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("filtered")]
 
    public async Task<IActionResult> GetFiltered([FromQuery] FilterCustomersModel filter)
    {
        var customers = await _customerService.GetFiltered(filter);
        return Ok(customers);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateCustomerModel model)
    {
       
        return Ok(await _customerService.Add(model));
    }
}
