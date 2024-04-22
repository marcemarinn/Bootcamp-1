using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Services;
using Core.Requests;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ServicePaymenController : BaseApiController
{
    private readonly IServicePaymentService _servicePaymenService;

    public ServicePaymenController(IServicePaymentService servicePaymenService)
    {
        _servicePaymenService = servicePaymenService;
    }

    [HttpPost]
    public async Task<ServicePaymentDTO> Create(ServicePaymentRequest request)
    {
        return await _servicePaymenService.Create(request);
    }

}
