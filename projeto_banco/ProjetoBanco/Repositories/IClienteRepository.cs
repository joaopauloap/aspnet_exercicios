using ProjetoBanco.Areas.Identity.Data;

namespace ProjetoBanco.Repositories
{
    public interface IClienteRepository
    {
        public Cliente BuscarClientePorId(string id);
        public Cliente BuscarClientePorChavePix(string chavePix);
        public bool VerificarCpf(string cpf);
        public bool VerificarSaldo(string id, decimal valor);
        public void Depositar(string id, decimal valor);
        public void Transferir(string id, TipoChavePix tipoChave, string chavePix, decimal valor);
        public void Atualizar(Cliente cliente);
        public void Salvar();
    }
}
