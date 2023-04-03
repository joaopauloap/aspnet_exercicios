using PetShopApi.Models;

namespace PetShopApi.Dtos.ConsultaDtos
{
    public class ReadConsultaDto
    {
        public int AnimalId { get; set; }
        public int VeterinarioId { get; set; }

        public Animal Animal { get; set; }
        public Veterinario Veterinario { get; set; }

        public DateTime DataHora { get; set; }
    }
}
