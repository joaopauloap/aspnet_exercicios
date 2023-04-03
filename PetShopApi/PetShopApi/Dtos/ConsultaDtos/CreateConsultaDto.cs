using PetShopApi.Models;

namespace PetShopApi.Dtos.ConsultaDtos
{
    public class CreateConsultaDto
    {
        public int AnimalId { get; set; }
        public int VeterinarioId { get; set; }
        public DateTime DataHora { get; set; }
    }
}
