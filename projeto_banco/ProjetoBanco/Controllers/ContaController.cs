using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBanco.Areas.Identity.Data;
using ProjetoBanco.Models;
using ProjetoBanco.Repositories;
using ProjetoBanco.ViewModels;

namespace ProjetoBanco.Controllers
{
    public class ContaController : Controller
    {
        private IChavePixRepository _chavePixRepository;
        private IClienteRepository _clienteRepository;
        private UserManager<Cliente> _userManager;

        public ContaController(IClienteRepository clienteRepository, UserManager<Cliente> userManager, IChavePixRepository chavePixRepository)
        {
            _chavePixRepository = chavePixRepository;
            _clienteRepository = clienteRepository;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            string idClienteLogado = _userManager.GetUserId(User);
            Cliente clienteLogado = _clienteRepository.BuscarClientePorId(idClienteLogado);

            List<ChavePix> listaChavesPix = _chavePixRepository.BuscarTodasPorContaId(clienteLogado.ContaId);

            ClienteViewModel viewModel = new ClienteViewModel()
            {
                Cliente = clienteLogado,
                Conta = clienteLogado.Conta,
                ListaChavesPix = listaChavesPix
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Depositar(string valor)
        {
            string idClienteLogado = _userManager.GetUserId(User);
            Cliente clienteLogado = _clienteRepository.BuscarClientePorId(idClienteLogado);

            valor = valor.Replace(".", ",");
            decimal valorDecimal = Convert.ToDecimal(valor);

            _clienteRepository.Depositar(idClienteLogado, valorDecimal);
            clienteLogado.VerificarTipoCliente();
            _clienteRepository.Atualizar(clienteLogado);
            _clienteRepository.Salvar();

            TempData["msg"] = "Depósito realizado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Transferir(TipoChavePix tipoChave, string chavePix, string valor)
        {
            string idClienteLogado = _userManager.GetUserId(User);
            Cliente clienteLogado = _clienteRepository.BuscarClientePorId(idClienteLogado);
            Cliente beneficiario = _clienteRepository.BuscarClientePorChavePix(chavePix);
            valor = valor.Replace(".", ",");
            decimal valorDecimal = Convert.ToDecimal(valor);
            bool testeSaldo = _clienteRepository.VerificarSaldo(idClienteLogado,valorDecimal);

            if (testeSaldo==false)
            {
                TempData["erro"] = "Saldo insuficiente!";
                return RedirectToAction("Index");
            }

            if (beneficiario == null)
            {
                TempData["erro"] = "Cliente não encontrado para esta chave pix!";
                return RedirectToAction("Index");
            }

            _clienteRepository.Transferir(idClienteLogado, tipoChave, chavePix, valorDecimal);
            clienteLogado.VerificarTipoCliente();
            beneficiario.VerificarTipoCliente();
            _clienteRepository.Atualizar(clienteLogado);
            _clienteRepository.Salvar();

            TempData["msg"] = "Transferência realizada com sucesso!";
            return RedirectToAction("Index");
        }


    }
}
