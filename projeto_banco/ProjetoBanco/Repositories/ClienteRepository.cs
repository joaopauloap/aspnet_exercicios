using Microsoft.EntityFrameworkCore;
using ProjetoBanco.Areas.Identity.Data;
using ProjetoBanco.Models;

namespace ProjetoBanco.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private BancoContext _context;
        public ClienteRepository(BancoContext context)
        {
            _context = context;
        }

        public Cliente BuscarClientePorId(string id)
        {
            //return _context.Clientes.Find(id);
            return _context.Clientes.Include(c => c.Conta).Where(c => c.Id == id).FirstOrDefault();
        }

        public bool VerificarCpf(string cpf)
        {
            return _context.Clientes.Any(c => c.Cpf == cpf);
        }

        public Cliente BuscarClientePorChavePix(string chavePixInformada)
        {
            int? contaId = _context.ChavesPix.Where(cp => cp.Chave == chavePixInformada).Select(cp=>cp.ContaId).FirstOrDefault();
            Cliente? cliente = _context.Clientes.Include(c => c.Conta).Where(c => c.ContaId == contaId).FirstOrDefault();
            return cliente;
        }

        public bool VerificarSaldo(string idClienteLogado, decimal valorPretendido)
        {
            Cliente cliente = BuscarClientePorId(idClienteLogado);
            if (cliente.Conta.Saldo >= valorPretendido)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
        }              

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public void Depositar(string id, decimal valor)
        {
            Cliente cliente = BuscarClientePorId(id);
            cliente.Conta.Depositar(valor);
        }

        public void Transferir(string idClienteLogado, TipoChavePix tipoChave, string chavePix, decimal valor)
        {
            //Atualiza o saldo da pessoa que está enviando
            Cliente cliente = BuscarClientePorId(idClienteLogado);
            cliente.Conta.Transferir(valor);

            //Atualiza o saldo da pessoa que está recebendo
            Conta Beneficiario = _context.ChavesPix.Where(ch => (ch.Chave == chavePix) && (ch.Tipo == tipoChave)).Include(receiver => receiver.Conta).Select(receiver => receiver.Conta).FirstOrDefault();
            Beneficiario.Saldo += valor;

        }

    }
}
