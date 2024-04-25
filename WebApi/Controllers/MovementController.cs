using Core.Interfaces.Services;
using Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class MovementController : BaseApiController
{
    private readonly IMovementService _movementService;

    public MovementController(IMovementService movementService)
    {
        _movementService = movementService;
    }

     
    [HttpGet]
    public async Task<IActionResult> GetFiltered([FromQuery] FilterMovementRequest filter)
    {


        return Ok(await _movementService.GetFiltered(filter));
    }
}
