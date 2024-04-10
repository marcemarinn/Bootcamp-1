using Core.Models;
using Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ICreditCardService
    {
        Task<CreditCardDTO> Add(CreateCreditCardModel model);
        Task<CreditCardDTO> GetById(int id);
        Task<CreditCardDTO> Update(CreditCardDTO model);

        Task<bool> Delete(int id);

        Task<List<CreditCardDTO>> GetAll();

        //Task<bool> NameIsAlreadyTaken(string name);

    }
}
