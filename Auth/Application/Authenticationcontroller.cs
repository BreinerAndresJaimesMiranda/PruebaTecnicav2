using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PruebaTecnica.Auth.Application
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authenticationcontroller : Controller
    {
        private readonly string secretkey;

        public Authenticationcontroller(IConfiguration config)
        {
            secretkey= config.GetSection("settings").GetSection("secretkey").ToString();
        }

        [HttpPost]
        public IActionResult GenerateToken(string Contrasenia)
        {
            if (Contrasenia == "Prueba")
            {
                var keybytes = Encoding.ASCII.GetBytes(secretkey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier,Contrasenia));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims, 
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keybytes),SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                string tokencreado = tokenHandler.WriteToken(tokenConfig);
                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { token = "" });
            }
        }
    }
}
