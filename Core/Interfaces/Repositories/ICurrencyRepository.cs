using Core.Requests;
using Core.DTOs;

namespace Core.Interfaces.Repositories
{
    public interface ICurrencyRepository
    {
        Task<List<CurrencyDTO>> GetFiltered(FilterCurrencyModel filter);

        Task <CurrencyDTO> Add(CreateCurrencyModel model);

    }
}


