using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApi.Models
{
    public class Veterinario
    {
        [Column("Id")]
        public int VeterinarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Especialidade { get; set; }

        //relacionamentos
        public ContratoTrabalho ContratoTrabalho { get; set; }
        public int ContratoTrabalhoId { get; set; } //chave estrangeira

        public ICollection<Consulta> Consultas { get; set; }
    }
}
