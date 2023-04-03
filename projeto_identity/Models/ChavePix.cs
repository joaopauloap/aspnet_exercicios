namespace ProjetoBanco.Models
{
    public class ChavePix
    {
        public int ChavePixId { get; set; }
        public string Chave { get; set; }
        public TipoChavePix Tipo { get; set; }


        public string GerarChaveAleatoria()
        {
            return "";
        }
    }

    public enum TipoChavePix
    {
        Cpf, Email, Telefone, Aleatorio
    }
}
