using AutoMapper;
using UsuarioAPI.Dtos;
using UsuarioAPI.Models;

namespace UsuarioAPI.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
