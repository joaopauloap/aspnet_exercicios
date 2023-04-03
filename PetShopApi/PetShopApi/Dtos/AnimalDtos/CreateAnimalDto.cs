using PetShopApi.Models;
using System.ComponentModel.DataAnnotations;

namespace PetShopApi.Dtos.AnimalDtos
{
    public class CreateAnimalDto
    {
        public string Nome { get; set; }
        [Range(1, 25, ErrorMessage = "Peso deve estar entre 1 a 25 Kg")]
        public decimal? Peso { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Castrado { get; set; }
        [Required, Range(0, 5, ErrorMessage = "Espécie fora dos indices")]
        public Especie Especie { get; set; }
        public int? PlanoId { get; set; }
    }
}
