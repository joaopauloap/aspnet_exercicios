namespace ProjetoBanco.Models
{
    public class ContaCorrente : Conta
    {
        public decimal TaxaManutencao { get; set; }
    
        public decimal DescontarTaxa (decimal quantia)
        {
            return quantia;
        }
        public override void Transferir (decimal quantia)
        {
            
        }
        public override void Depositar (decimal quantia)
        {
           
        }
    }
}
