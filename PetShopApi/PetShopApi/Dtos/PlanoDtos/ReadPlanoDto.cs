using PetShopApi.Models;

namespace PetShopApi.Dtos.PlanoDtos
{
    public class ReadPlanoDto
    {
        public int PlanoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public ICollection<Animal>? Animais { get; set; }
    }
}
