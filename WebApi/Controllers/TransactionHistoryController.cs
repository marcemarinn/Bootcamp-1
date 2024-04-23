using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace WebApi.Controllers;

public class TransactionHistoryController : BaseApiController
{
    private readonly ITransactionHistoryService _transactionHistoryService;

    public TransactionHistoryController(ITransactionHistoryService transactionHistoryService)
    {
        _transactionHistoryService = transactionHistoryService;
    }

    [HttpGet]

    public async Task<IActionResult> GetFilteredTransactions([FromQuery] FilterMovementRequest filter)
    {
        return Ok(await _transactionHistoryService.GetFilteredTransactions(filter));
    }
}
