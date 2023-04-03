using System.ComponentModel.DataAnnotations;

namespace ProjetoCRUD.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento"), DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public string Genero { get; set; }
        public Estado Estado { get; set; }
    }

    public enum Estado
    {
        Selecione, AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO
    }
}
