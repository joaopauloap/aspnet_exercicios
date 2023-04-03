using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_SQLSERVER.Models
{
    [Table("Tbl_Veterinario")]
    public class Veterinario
    {
        [Column("Id")]
        public int VeterinarioId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório."), MaxLength(80)]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter no minimo 3 e no máximo 80 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Especialidade é obrigatório"), MaxLength(40)]
        public string Especialidade { get; set; }


        //Relação 1:1
        public ContratoTrabalho ContratoTrabalho { get; set; }
        public int ContratoTrabalhoId { get; set; }


        //Relação N:M
        public ICollection<AnimalVeterinario>? AnimaisVeterinarios { get; set; }
    }
}
