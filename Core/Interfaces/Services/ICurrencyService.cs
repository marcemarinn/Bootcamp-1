using Core.Models;
using Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ICurrencyService
    {
    Task<List<CurrencyDTO>> GetFiltered(FilterCurrencyModel filter);

    Task<CurrencyDTO> Add(CreateCurrencyModel filter);



    }
}
