using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_SQLSERVER.Models
{
    //Tabela Associativa
    //Relação N:N muitos para muitos
    [Table("Tbl_Animal_Veterinario")]
    public class AnimalVeterinario
    {
        public Veterinario Veterinario { get; set; }
        public int VeterinarioId { get; set; }  


        public Animal Animal { get; set; }
        public int AnimalId { get; set; }

        public DateTime DataHora { get; set; }
    }
}
