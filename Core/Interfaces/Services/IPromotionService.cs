using Core.DTOs;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface IPromotionService
{

    Task<PromotionDTO> Create(CreatePromotionRequest model);
    Task<PromotionDTO> Update(PromotionDTO request);


}