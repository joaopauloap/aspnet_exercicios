using System.ComponentModel.DataAnnotations;

namespace PetShopApi.Dtos.PlanoDtos
{
    public class CreatePlanoDto
    {

        [Required]
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
    }
}
