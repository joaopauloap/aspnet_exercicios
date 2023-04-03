namespace ProjetoBanco.Models
{
    public class ContaPoupanca : Conta
    {
        public decimal TaxaRendimento { get; set; }

        public decimal AcrescentarRendimento(decimal quantia)
        {
            return quantia;
        }

        public override void Transferir(decimal quantia)
        {

        }

        public override void Depositar(decimal quantia)
        {

        }
    }
}
