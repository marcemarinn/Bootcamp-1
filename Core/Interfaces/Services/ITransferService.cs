using Core.DTOs;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface ITransferService
{
    Task<TransferDTO> Create(TransferRequest request);


}
