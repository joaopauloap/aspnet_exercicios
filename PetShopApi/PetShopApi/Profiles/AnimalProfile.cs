using AutoMapper;
using PetShopApi.Dtos.AnimalDtos;
using PetShopApi.Models;

namespace PetShopApi.Profiles
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<CreateAnimalDto,Animal>();
            CreateMap<Animal,ReadAnimalDto>();
            CreateMap<UpdateAnimalDto,Animal>();
        }
    }
}
