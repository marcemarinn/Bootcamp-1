using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CreditCardRepository :ICreditCardRepository

    {

        private readonly Bootcampp2Context _context;

        public CreditCardRepository(Bootcampp2Context context)
        {
            _context = context;
        }

        public async Task<CreditCardDTO> Add(CreateCreditCardModel model)
        {
            var creditCardToCreate = model.Adapt<CreditCard>();
            _context.CreditCards.Add(creditCardToCreate);

            await _context.SaveChangesAsync();

            var creditCardDTO = creditCardToCreate.Adapt<CreditCardDTO>();

            return creditCardDTO;
        }

        public async Task<CreditCardDTO> GetById(int id)
        {


            var creditCard = await _context.CreditCards.FindAsync(id);
        
            //if (creditCard is null)
               // throw new NotFoundException($"CreditCard with id: {id} doest not exist");

            var creditCardDTO = creditCard.Adapt<CreditCardDTO>();

            return creditCardDTO;
        }

        public async Task<CreditCardDTO> Update(CreditCardDTO model)
        {
            var creditCard = await _context.CreditCards.FindAsync(model.Id);

            if (creditCard is null) throw new Exception("creditCard was not found");

            model.Adapt(creditCard);

            _context.CreditCards.Update(creditCard);

            await _context.SaveChangesAsync();

            var creditCardDTO = creditCard.Adapt<CreditCardDTO>();

            return creditCardDTO;
        }

        public async Task<bool> Delete(int id )
        {
            var creditCard = await _context.CreditCards.FindAsync(id);

            if (creditCard is null) throw new Exception("creditCard was not found");

            id.Adapt(creditCard);

            _context.CreditCards.Remove(creditCard);

            await _context.SaveChangesAsync();

            var result = await _context.SaveChangesAsync();

            return result < 0;

        }

        public async Task<List<CreditCardDTO>> GetAll()
        {
            var creditCards = await _context.CreditCards.ToListAsync();

            var creditCardsDTO = creditCards.Adapt<List<CreditCardDTO>>();

            return creditCardsDTO;
        }
    }
}
