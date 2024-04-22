using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface ITransferService
{

    Task <TransferDTO> Create(TransferRequest request);
}
