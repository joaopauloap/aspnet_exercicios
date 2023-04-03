namespace ProjetoBanco.Models
{
    public class ContaCorrente : Conta
    {
        public decimal TaxaManutencao { get; set; }

        public ContaCorrente()
        {
            Random rnd = new Random();
            int contaNum = rnd.Next(10000, 99999);

            Random dig = new Random();
            int digito = dig.Next(0, 4);

            string numeroConta = $"{contaNum}-{digito}";

            this.Saldo = 0;
            this.Numero = numeroConta;
            this.Tipo = TipoConta.Corrente;

            this.TaxaManutencao = 0.03m;
        }

        public decimal DescontarTaxa (decimal quantia)
        {
            quantia += quantia * this.TaxaManutencao;

            return quantia;
        }

        public override void Transferir (decimal quantia)
        {
            decimal valor = this.DescontarTaxa(quantia);

            this.Saldo -= valor;            
        }
        public override void Depositar (decimal quantia)
        {
           this.Saldo += quantia;
        }
    }
}
