using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PromotionRepository : IPromotionRepository
{
    private readonly Bootcampp2Context _bootcampp2Context;

    public PromotionRepository(Bootcampp2Context bootcampp2Context)
    {
        _bootcampp2Context = bootcampp2Context;
    }

    public async Task<PromotionDTO> Create(CreatePromotionRequest model)
    {
        var promotionToCreate = model.Adapt<Promotion>();

        _bootcampp2Context.Promotions.Add(promotionToCreate);
        await _bootcampp2Context.SaveChangesAsync();

        if (model.CompanyIds != null && model.CompanyIds.Any())
        {
            foreach (var companyId in model.CompanyIds)
            {
                var companyPromotion = new CompanyPromotion
                {
                    CompanyId = companyId,
                    PromotionId = promotionToCreate.Id 
                };
                _bootcampp2Context.CompaniesPromotion.Add(companyPromotion);
            }
            await _bootcampp2Context.SaveChangesAsync();
        }

        var promotionDTO = promotionToCreate.Adapt<PromotionDTO>();
        return promotionDTO;

    }


}
