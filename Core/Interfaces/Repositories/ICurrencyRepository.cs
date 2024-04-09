using Core.Models;
using Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ICurrencyRepository
    {
        Task<List<CurrencyDTO>> GetFiltered(FilterCurrencyModel filter);

        Task<List<CurrencyDTO>> Add(CreateCurrencyModel model);

    }
}


