using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjetoBanco.Models;

namespace ProjetoBanco.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Cliente class
public class Cliente : IdentityUser
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public DateTime DataNascimento { get; set; }

    public TipoCliente TipoCliente { get; set; }

    //Relacionamento
    public Conta Conta { get; set; }
    public int ContaId { get; set; }

    public void VerificarTipoCliente()
    {
        if (Conta.Saldo >= 15000)
            TipoCliente = TipoCliente.Premium;
        else if (Conta.Saldo >= 5000 && Conta.Saldo < 15000)
            TipoCliente = TipoCliente.Super;
        else
            TipoCliente = TipoCliente.Comum;
    }
}

public enum TipoCliente
{
    Comum, Super, Premium
}