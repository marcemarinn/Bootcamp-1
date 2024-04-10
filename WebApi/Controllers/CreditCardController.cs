using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;
using Infrastructure.Services;
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
        public async Task<IActionResult> Add([FromBody] CreateCreditCardModel model)
        {
            
            return Ok(await _service.Add(model));
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {

            return Ok(await _service.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CreditCardDTO model)
        {

            return Ok(await _service.Update(model));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {

            return Ok(await _service.Delete(id));
        }

        [HttpGet("/all")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _service.GetAll());
        }
    }
}
