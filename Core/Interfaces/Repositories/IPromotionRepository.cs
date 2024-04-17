using Core.DTOs;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface IPromotionRepository
{

    Task<PromotionDTO> Create(CreatePromotionRequest model);

    Task<PromotionDTO> Update(PromotionDTO model);




}
