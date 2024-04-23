using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class TransferController : BaseApiController
{
    private readonly ITransferService _transferService;

    public TransferController(ITransferService transferService)
    {
        _transferService = transferService;
    }

    [HttpPost]
    public Task<TransferDTO> Create(TransferRequest request)
    {
        return _transferService.Create(request);
    }

}
