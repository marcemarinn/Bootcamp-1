using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface IProductRequestRepository
{

    Task <ProductRequestDTO>  Create(ProductRequestModel request);
}
