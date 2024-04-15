using Core.DTOs;
using Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AccountDTO> Create (CreateAccountRequest model);
        Task<List<AccountDTO>> GetById(int id);
        Task<bool> Delete(int id);
        Task <List<AccountDTO>> Filter(FilterAccountModel model);





    }
}
