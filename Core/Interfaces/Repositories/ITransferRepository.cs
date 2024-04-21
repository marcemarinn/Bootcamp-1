using Core.DTOs;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface ITransferRepository
{
    Task <TransferDTO> Create(TransferRequest request);



}
