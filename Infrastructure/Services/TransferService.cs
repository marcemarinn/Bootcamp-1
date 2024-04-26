using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;

namespace Infrastructure.Services;

public class TransferService : ITransferService
{

    private readonly ITransferRepository _transferRepository;
    private readonly BootcampContext _bootcampContext;

    public TransferService(ITransferRepository transferRepository, BootcampContext context)
    {
        _transferRepository = transferRepository;
        _bootcampContext = context;
    }

    public async Task<TransferDTO> Create(TransferRequest request)
    {

       
        return await _transferRepository.Create(request);

    }
   



}
