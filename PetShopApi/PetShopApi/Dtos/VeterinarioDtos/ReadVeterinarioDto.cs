using PetShopApi.Models;

namespace PetShopApi.Dtos.VeterinarioDtos
{
    public class ReadVeterinarioDto
    {
        public int VeterinarioId { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }

        //relacionamentos
        public ContratoTrabalho ContratoTrabalho { get; set; }
        public int ContratoTrabalhoId { get; set; } //chave estrangeira
    }
}
