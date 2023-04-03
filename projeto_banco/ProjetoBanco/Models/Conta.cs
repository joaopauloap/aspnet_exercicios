﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBanco.Models
{
    public abstract class Conta
    {
        
        public int ContaId { get; set; }
        public string Numero { get; set; }
        public decimal Saldo { get; set; }
        public TipoConta Tipo { get; set; }

        ICollection<ChavePix> ChavesPix { get; set; }

        public abstract void Transferir(decimal quantia);

        public abstract void Depositar(decimal quantia);

    }
    public enum TipoConta
    {
        Corrente, Poupança
    }
}
