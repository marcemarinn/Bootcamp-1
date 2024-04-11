using Core.Models;
using Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<AccountDTO> Add(CreateAccountModel model);
        Task<AccountDTO> GetById(int id);



    }
}
