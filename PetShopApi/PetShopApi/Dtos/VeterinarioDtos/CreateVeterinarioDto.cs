using PetShopApi.Models;
using System.ComponentModel.DataAnnotations;

namespace PetShopApi.Dtos.VeterinarioDtos
{
    public class CreateVeterinarioDto
    {
        public int VeterinarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Especialidade { get; set; }
        //relacionamentos
        public ContratoTrabalho ContratoTrabalho { get; set; }
    }
}
