using Core.Entities;
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
    public class CreditCardService : ICreditCardService
    {

        private readonly ICreditCardRepository _CreditCardRepository;

        public CreditCardService(ICreditCardRepository creditCard)
        {
            _CreditCardRepository = creditCard;
        }

        public async Task<CreditCardDTO> Add(CreateCreditCardModel model)
        {
            return await _CreditCardRepository.Add(model);
        }

        public async Task<bool> Delete(int id)
        {
            return await _CreditCardRepository.Delete( id);
        }

        public async Task<CreditCardDTO> GetById(int id)
        {
            return await _CreditCardRepository.GetById(id);
        }

        public async Task<CreditCardDTO> Update(CreditCardDTO model)
        {
            return await _CreditCardRepository.Update(model);
        }

        public async Task<List<CreditCardDTO>> GetAll()
        {
            return await _CreditCardRepository.GetAll();
        }
    }
}
