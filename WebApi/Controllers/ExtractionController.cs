using Core.Interfaces.Services;
using Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ExtractionController : BaseApiController
{
    private readonly IExtractionService _extractionService;

    public ExtractionController(IExtractionService extractionService)
    {
        _extractionService = extractionService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(ExtractionRequest request)
    {
        return Ok(await _extractionService.Create(request));
    }

}
