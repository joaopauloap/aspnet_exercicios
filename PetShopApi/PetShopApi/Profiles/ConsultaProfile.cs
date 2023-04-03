using AutoMapper;
using PetShopApi.Dtos.ConsultaDtos;
using PetShopApi.Models;

namespace PetShopApi.Profiles
{
    public class ConsultaProfile : Profile
    {
        public ConsultaProfile()
        {
            CreateMap<CreateConsultaDto, Consulta>();
            CreateMap<Consulta, ReadConsultaDto>();
        }
    }
}
