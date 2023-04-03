using AutoMapper;
using PetShopApi.Dtos.PlanoDtos;
using PetShopApi.Models;

namespace PetShopApi.Profiles
{
    public class PlanoProfile : Profile
    {
        public PlanoProfile()
        {
            CreateMap<CreatePlanoDto, Plano>();
            CreateMap<Plano, ReadPlanoDto>();
            CreateMap<UpdatePlanoDto, Plano>();
        }
    }
}
