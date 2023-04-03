using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_SQLSERVER.Models
{
    [Table("Tbl_Animal")]
    public class Animal
    {
        [Column("Id"),Key]
        public int AnimalId { get; set; }
        [Required,MaxLength(50)]
        public string Nome{ get; set; }
        public decimal Peso { get; set; }
        [Column("Dt_Nascimento"),Required, Display(Name = "Data de Nascimento"), DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public bool Castrado { get; set; }
        [Required]
        public Especie Especie { get; set; }

        //Relação N:1 (Muitos para um)
        public Plano Plano { get; set; }
        public int? PlanoId { get; set; }

        //N:M
        public ICollection<AnimalVeterinario> AnimaisVeterinarios { get; set; }
    }

    public enum Especie
    {
        Cachorro,Gato,Peixe,Rato,Coelho,Ave
    }
}
