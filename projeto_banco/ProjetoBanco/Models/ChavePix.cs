using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBanco.Models
{
    public class ChavePix
    {
        public int ChavePixId { get; set; }

        public string Chave { get; set; }

        public TipoChavePix Tipo { get; set; }
        
        public Conta Conta { get; set; }

        public int ContaId { get; set; }

        public void GerarChaveAleatoria()
        {
            var chaveAleatoria = Guid.NewGuid().ToString();
            this.Chave = chaveAleatoria;
        }
    }
}
public enum TipoChavePix
{
    Cpf, Email, Telefone, Aleatoria
}

