using Core.DTOs;
using Core.Entities;
using Core.Requests;

namespace Core.Interfaces.Repositories
{
    public interface ICompanyPromotionRepository
    {

        public Task<CompanyPromotionDTO> Create(CreateCompanyPromotionRequest resquest);
    }
}
