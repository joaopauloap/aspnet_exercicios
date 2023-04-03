using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApi.Models
{
    public class Animal
    {
        [Column("Id")]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(20, ErrorMessage = "Máximo de 20 Caracteres")]
        public string Nome { get; set; }
        [Range(1,25,ErrorMessage = "Peso deve estar entre 1 a 25 Kg")]
        public decimal? Peso { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Castrado { get; set; }
        [Required, Range(0,5,ErrorMessage = "Espécie fora dos indices")]
        public Especie Especie { get; set; }

        //Relacionamentos
        public Plano? Plano { get; set; }
        public int? PlanoId { get; set; }

        public ICollection<Consulta> Consultas { get; set; }
    }

    public enum Especie
    {
        Cachorro, Gato, Peixe, Rato, Coelho, Ave
    }
}
