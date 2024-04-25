using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface IProductRequestService
{
    Task <int> Create(ProductRequestModel model);

}
