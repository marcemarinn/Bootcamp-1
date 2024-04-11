using Core.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebApi.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IJwtProvider _jwtProvider;

        public AuthController(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }

        [HttpGet("generate-token")]
        [AllowAnonymous]
        public IActionResult Generate()
        {
            string token = _jwtProvider.Generate();

            return Ok(token);
        }

        [HttpGet("protected-endpoint")]
        [Authorize]
        public IActionResult ProtectedEndpoint()
        {

            return Ok("Esto es un endpoint protegido");
        }

        [HttpGet("protected-endpoint-seguridad")]
        [Authorize(Roles = "Seguridad")]
        public IActionResult ProtectedEndpoint2()
        {

            return Ok("Esto solo puede acceder un miembro de Seguridad");
        }

        [HttpGet("protected-endpoint-admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult ProtectedEndpoint3()
        {

            return Ok("Esto solo puede acceder un Administrador");
        }

        [HttpGet("protected-endpoint-ambos")]
        [Authorize(Roles = "Admin,Seguridad")]
        public IActionResult ProtectedEndpoint4()
        {

            return Ok("Esto endpoint pueden ver Seguridad y Admin");
        }


        //    [HttpPost]
        //    public ActionResult Token(UserLogin credenciales)
        //    {
        //        if (_jwtProvider.ValidateLogin(credenciales.Username, credenciales.Password))
        //        {
        //            var fechaActual = DateTime.UtcNow;
        //            var validez = TimeSpan.FromHours(5);
        //            var fechaExpiracion = fechaActual.Add(validez);

        //            var token = _jwtProvider.GenerateToken(fechaActual, credenciales.Username, validez);
        //            return Ok(new
        //            {
        //                Token = token,
        //                ExpireAt = fechaExpiracion
        //            });
        //        }
        //        return StatusCode(401);
        //    }


        //}
    }

}
