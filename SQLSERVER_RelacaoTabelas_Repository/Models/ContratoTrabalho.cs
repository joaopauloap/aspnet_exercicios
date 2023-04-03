using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_SQLSERVER.Models
{
    [Table("Tbl_Contrato_Trabalho")]
    public class ContratoTrabalho
    {
        [Column("Id"),Key]
        public int ContratoTrabalhoId { get; set; }

        [Column("Dt_Contratacao", TypeName = "date"), Display(Name = "Data de contratação"), DataType(DataType.Date)]
        public DateTime DataContratacao { get; set; }
        public TipoContrato Tipo { get; set; }
        public decimal Valor { get; set; }

    }

    public enum TipoContrato
    {
        Clt, Pj
    }
}
