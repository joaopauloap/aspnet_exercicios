using ProjetoBanco.Areas.Identity.Data;
using ProjetoBanco.Models;

namespace ProjetoBanco.ViewModels
{
    public class ClienteViewModel
    {
        public Cliente Cliente { get; set; }
        public Conta Conta { get; set; }
        public List<ChavePix> ListaChavesPix{ get; set; }
    }
}
