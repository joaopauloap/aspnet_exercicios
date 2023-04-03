using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApi.Models
{
    [Table("tb_consulta")]
    public class Consulta   //Tabela Associativa (Muitos-Muitos) entre Animal-Veterinario
    {
        public int AnimalId { get; set; }
        public int VeterinarioId { get; set; }

        public Animal Animal { get; set; }
        public Veterinario Veterinario { get; set; }

        public DateTime DataHora { get; set; }
    }
}
