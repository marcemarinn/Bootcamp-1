using Core.Requests;
using Core.DTOs;


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
