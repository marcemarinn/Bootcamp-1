using Core.Interfaces.Services;
using Core.Requests;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class MovementController : BaseApiController
{
    private readonly IMovementService _movementService;

    public MovementController(IMovementService movementService)
    {
        _movementService = movementService;
    }

     
    [HttpGet("{AccountId}")]
    public async Task<IActionResult> GetFiltered([FromQuery] FilterMovementRequest filter,int accountId)
    {
        return Ok(await _movementService.GetFiltered(filter,accountId));
    }
}
