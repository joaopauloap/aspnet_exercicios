namespace ProjetoBanco.Models
{
    public class ContaPoupanca : Conta
    {
        public decimal TaxaRendimento { get; set; }

        public ContaPoupanca()
        {
            Random rnd = new Random();
            int contaNum = rnd.Next(10000, 99999);

            Random dig = new Random();
            int digito = dig.Next(0, 4);

            string numeroConta = $"{contaNum}-{digito}";

            this.Saldo = 0;
            this.Numero = numeroConta;
            this.Tipo = TipoConta.Poupança;

            this.TaxaRendimento = 0.01m;
        }

        public decimal AcrescentarRendimento(decimal quantia)
        {
            quantia += quantia * TaxaRendimento;
            return quantia;
        }

        public override void Transferir(decimal quantia)
        {
            this.Saldo -= quantia;
        }

        public override void Depositar(decimal quantia)
        {
            this.Saldo += this.AcrescentarRendimento(quantia);

        }
    }
}
