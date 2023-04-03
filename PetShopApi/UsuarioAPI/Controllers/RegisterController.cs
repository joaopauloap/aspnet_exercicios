using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Dtos;
using UsuarioAPI.Models;

namespace UsuarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private UserManager<Usuario> _userManager;
        private IMapper _mapper;
        public RegisterController(UserManager<Usuario> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            var identityResult = _userManager.CreateAsync(usuario, usuarioDto.Password);
            if (!identityResult.Result.Succeeded)
            {
                return StatusCode(500);
            }
            return Ok();
        }
    }
}
