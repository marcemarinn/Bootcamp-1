using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ProductRequestService : IProductRequestService
{

    private readonly IProductRequestRepository _repository;

    public ProductRequestService(IProductRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductRequestDTO> Create(ProductRequestModel model)
    {
        return  await _repository.Create(model);
    }
}
