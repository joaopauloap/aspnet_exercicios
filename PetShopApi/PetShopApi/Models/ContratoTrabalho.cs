using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApi.Models
{
    public class ContratoTrabalho
    {
        [Column("Id")]
        public int ContratoTrabalhoId { get; set; }

        [Required]
        [Column (TypeName = "date")]
        public DateTime DataContratacao { get; set; }
        public TipoContrato Tipo { get; set; }
        public decimal Valor { get; set; }
    }

    public enum TipoContrato
    {
        Clt, Pj
    }
}
