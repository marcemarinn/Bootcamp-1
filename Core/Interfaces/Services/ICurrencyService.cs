using Core.Requests;
using Core.DTOs;


namespace Core.Interfaces.Services
{
    public interface ICurrencyService
    {
    Task<List<CurrencyDTO>> GetFiltered(FilterCurrencyModel filter);

    Task<CurrencyDTO> Add(CreateCurrencyModel filter);



    }
}
