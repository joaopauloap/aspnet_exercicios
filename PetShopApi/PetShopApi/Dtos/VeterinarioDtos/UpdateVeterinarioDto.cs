using PetShopApi.Models;
using System.ComponentModel.DataAnnotations;

namespace PetShopApi.Dtos.VeterinarioDtos
{
    public class UpdateVeterinarioDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Especialidade { get; set; }
    }
}
