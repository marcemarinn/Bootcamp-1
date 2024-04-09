using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
