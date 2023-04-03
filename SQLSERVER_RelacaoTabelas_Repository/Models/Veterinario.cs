using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_SQLSERVER.Models
{
    [Table("Tbl_Veterinario")]
    public class Veterinario
    {
        [Column("Id")]
        public int VeterinarioId { get; set; }

        [Required, MaxLength(80)]
        public string Nome { get; set; }

        [Required, MaxLength(40)]
        public string Especialidade { get; set; }


        //Relação 1:1
        public ContratoTrabalho ContratoTrabalho { get; set; }
        public int ContratoTrabalhoId { get; set; }


        //Relação N:M
        public ICollection<AnimalVeterinario> AnimaisVeterinarios { get; set; }
    }
}
