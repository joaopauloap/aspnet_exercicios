using PetShopApi.Models;
using System.ComponentModel.DataAnnotations;

namespace PetShopApi.Dtos.AnimalDtos
{
    public class ReadAnimalDto
    {
        public int AnimalId { get; set; }
        public string Nome { get; set; }
        public decimal? Peso { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Castrado { get; set; }
        public Especie Especie { get; set; }
        public DateTime DataDaConsulta { get; set; }
        public Plano? Plano { get; set; }
    }
}
