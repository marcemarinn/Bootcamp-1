using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TransferRepository : ITransferRepository
{
    private readonly Bootcampp2Context _bootcampp2Context;

    public TransferRepository(Bootcampp2Context bootcampp2Context)
    {
        _bootcampp2Context = bootcampp2Context;
    }

    public async Task<TransferDTO> Create(TransferRequest request)
    {
        var transferToCreate =  request.Adapt<Transfer>();

        _bootcampp2Context.Transfers.Add(transferToCreate);

        

    }
}
