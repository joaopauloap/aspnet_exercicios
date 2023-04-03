using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuarioAPI.Models;
using UsuarioAPI.Requests;

namespace UsuarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private SignInManager<Usuario> _signInManager;

        public LoginController(SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            var resultIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (!resultIdentity.Result.Succeeded)
            {
                return Unauthorized();
            }

            //gerar token jwt

            Usuario? usuario = _signInManager.UserManager.Users
                .Where(u => u.NormalizedUserName == request.UserName.ToUpper())
                .FirstOrDefault();

            Claim[] claims = new Claim[]
            {
                new Claim("username",usuario.UserName),
                new Claim("id",usuario.Id.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn"));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
                );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new Token(tokenString));
        }
    }
}
