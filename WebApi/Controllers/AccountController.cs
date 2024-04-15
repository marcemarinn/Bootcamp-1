using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApi.Controllers;

public class AccountController : BaseApiController
{

    private readonly IAccountService _accountService;

    public AccountController (IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]

    public async Task<IActionResult> Create([FromBody]CreateAccountRequest request)
    {
        
         return  Ok(await _accountService.Create(request));
    }

    [HttpGet]

    public async Task<IActionResult> GetById([FromQuery] int customerId)
    {

        return Ok(await _accountService.GetById(customerId));
    }

    [HttpDelete]

    public async Task<IActionResult> Delete([FromQuery] int id)
    {

        return Ok(await _accountService.Delete(id));
    }

    [HttpGet("/filter")]

    public async Task<IActionResult> Filter([FromQuery] FilterAccountModel filter)
    {

        return Ok(await _accountService.Filter(filter));
    }



}
