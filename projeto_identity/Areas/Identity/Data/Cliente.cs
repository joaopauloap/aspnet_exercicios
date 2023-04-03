using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace projeto_identity.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Cliente class
public class Cliente : IdentityUser
{ 
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Cpf { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    public TipoCliente Tipo { get; set; }
    
}

public enum TipoCliente
{
    Comum, Super, Premium
}

