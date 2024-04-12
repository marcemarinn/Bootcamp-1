using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Requests;

namespace Infrastructure.Services
{
    public class CurrencyService : ICurrencyService
    {

        private readonly ICurrencyRepository _repository;

        public CurrencyService(ICurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CurrencyDTO>> GetFiltered(FilterCurrencyModel filter)
        {
            return await _repository.GetFiltered(filter);
        }

        public async Task<CurrencyDTO> Add(CreateCurrencyModel model)
        {
            return await _repository.Add(model);

        }

    }
}
