using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Context;
using Mapster;

namespace Infrastructure.Repositories
{
    public class CompanyPromotionRepository : ICompanyPromotionRepository
    {
        private readonly Bootcampp2Context _bootcampp2Context;

        public CompanyPromotionRepository(Bootcampp2Context bootcampp2Context)
        {
            _bootcampp2Context = bootcampp2Context;
        }

        public async Task<CompanyPromotionDTO> Create(CreateCompanyPromotionRequest request)
        {
            var companyPromotionToCreate = request.Adapt<CompanyPromotion>();
            _bootcampp2Context.CompaniesPromotion.Add(companyPromotionToCreate);

            await _bootcampp2Context.SaveChangesAsync();

            var companyPromotionDTO = request.Adapt<CompanyPromotionDTO>();

            return companyPromotionDTO;

        }


    }
}