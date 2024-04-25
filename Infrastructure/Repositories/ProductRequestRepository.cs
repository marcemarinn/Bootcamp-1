using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;

namespace Infrastructure.Repositories;

public class ProductRequestRepository : IProductRequestRepository
{
    private readonly BootcampContext _bootcampContext;

    public ProductRequestRepository(BootcampContext bootcampContext)
    {
        _bootcampContext = bootcampContext;
    }



    public async Task<int> Create(ProductRequestModel request)
    {
        var productRequestToCreate =  request.Adapt<ProductRequest>();

        var productId = await _bootcampContext.Products.FindAsync(request.ProductId);

        if (productId == null)
        {
            throw new Exception("El ID de producto proporcionado no existe.");
        }

        _bootcampContext.ProductRequests.Add(productRequestToCreate);
        await _bootcampContext.SaveChangesAsync();


        return productRequestToCreate.Id;
    }
}
