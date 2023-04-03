using AutoMapper;
using PetShopApi.Dtos.VeterinarioDtos;
using PetShopApi.Models;

namespace PetShopApi.Profiles
{
    public class VeterinarioProfile : Profile
    {
        public VeterinarioProfile()
        {
        CreateMap<CreateVeterinarioDto,Veterinario>();
        CreateMap<Veterinario, ReadVeterinarioDto>();
        CreateMap<UpdateVeterinarioDto, Veterinario>();

        }
    }
}
