using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoBanco.Areas.Identity.Data;
using ProjetoBanco.Models;
using ProjetoBanco.Repositories;

namespace ProjetoBanco.Controllers
{
    public class ChavePixController : Controller
    {
        private IClienteRepository _clienteRepository;
        private IChavePixRepository _chavePixRepository;
        private UserManager<Cliente> _userManager;
        public ChavePixController(IChavePixRepository chavePixRepository, UserManager<Cliente> userManager, IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _chavePixRepository = chavePixRepository;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult CadastrarPix(ChavePix chavePix)
        {
            bool teste = _chavePixRepository.VerificarExistencia(chavePix.Chave);
            if (teste)
            {
                TempData["erro"] = "Esta chave pix já foi cadastrada!";
                return RedirectToAction("Index","Conta");
            }

            string idClienteLogado = _userManager.GetUserId(User);
            Cliente clienteLogado = _clienteRepository.BuscarClientePorId(idClienteLogado);
            chavePix.ContaId = clienteLogado.ContaId;

            if (chavePix.Tipo == TipoChavePix.Aleatoria)
                chavePix.GerarChaveAleatoria();

            _chavePixRepository.Cadastrar(chavePix);
            _chavePixRepository.Salvar();
            TempData["msg"] = "Chave Cadastrada com Sucesso!";
            return RedirectToAction("Index", "Conta");

        }

        [HttpPost]
        public IActionResult RemoverChave(int chaveId)
        {
            _chavePixRepository.Remover(chaveId);
            _chavePixRepository.Salvar();

            TempData["msg"] = "Chave Pix removida com sucesso!";
            return RedirectToAction("Index", "Conta");
        }
    }
}
