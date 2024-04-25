using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface IProductRequestRepository
{

    Task <int>  Create(ProductRequestModel request);
}
