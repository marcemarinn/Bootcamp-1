using Core.Interfaces.Services;
using Core.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtSettings;

        public JwtProvider(IOptions<JwtOptions> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string Generate()
        {
            var userRoles = new List<string> { "Admin"/*, "Seguridad"*/ };

            var claims = new Claim[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, "1"),
            new Claim(JwtRegisteredClaimNames.Email, "prueba@prueba.com"),
            new Claim(ClaimTypes.Role, string.Join(",", userRoles))
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    _jwtSettings.Issuer,
                    _jwtSettings.Audience,
                    claims,
                    null,
                    DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
                    signInCredentials
                );

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
        //    public string GenerateToken(DateTime fechaActual, string username, TimeSpan tiempoValidez)
        //    {
        //        var fechaExpiracion = fechaActual.Add(tiempoValidez);
        //        //Configuramos las claims
        //        var claims = new Claim[]
        //        {
        //        new Claim(JwtRegisteredClaimNames.Sub,username),
        //        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.Iat,
        //            new DateTimeOffset(fechaActual).ToUniversalTime().ToUnixTimeSeconds().ToString(),
        //            ClaimValueTypes.Integer64
        //        ),
        //        new Claim("roles","Cliente"),
        //        new Claim("roles","Administrador"),
        //        };

        //        //Añadimos las credenciales
        //        var signingCredentials = new SigningCredentials(
        //                new SymmetricSecurityKey(Encoding.ASCII.GetBytes("G3VF4C6KFV43JH6GKCDFGJH45V36JHGV3H4C6F3GJC63HG45GH6V345GHHJ4623FJL3HCVMO1P23PZ07W8")),
        //                SecurityAlgorithms.HmacSha256Signature
        //        );//luego se debe configurar para obtener estos valores, así como el issuer y audience desde el appsetings.json

        //        //Configuracion del jwt token
        //        var jwt = new JwtSecurityToken(
        //            issuer: "Peticionario",
        //            audience: "Public",
        //            claims: claims,
        //            notBefore: fechaActual,
        //            expires: fechaExpiracion,
        //            signingCredentials: signingCredentials
        //        );

        //        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        //        return encodedJwt;

        //}

        //    public bool ValidateLogin(string username, string password)
        //    {
        //        if (username.Equals("admin") && password.Equals("123456"))
        //            return true;
        //        return false;
        //    }
        //}
    }
}
