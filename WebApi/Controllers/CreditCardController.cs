using Core.DTOs;
using Core.Interfaces.Services;
using Core.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CreditCardController : BaseApiController
    {
        private readonly ICreditCardService _service;

        public CreditCardController(ICreditCardService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] CreateCreditCardModel model)
        {
            
            return Ok(await _service.Add(model));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {

            return Ok(await _service.GetById(id));
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] CreditCardDTO model)
        {

            return Ok(await _service.Update(model));
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {

            return Ok(await _service.Delete(id));
        }

        [HttpGet("/all")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _service.GetAll());
        }
    }
}
