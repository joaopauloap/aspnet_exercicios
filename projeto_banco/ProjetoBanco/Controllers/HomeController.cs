using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoBanco.Areas.Identity.Data;
using ProjetoBanco.Models;
using System.Diagnostics;

namespace ProjetoBanco.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SignInManager<Cliente> _cliente;
        public HomeController(ILogger<HomeController> logger, SignInManager<Cliente> cliente)
        {
            _logger = logger;
            _cliente = cliente;
        }

        public IActionResult Index()
        {
            if (_cliente.IsSignedIn(User))
            {
                return RedirectToAction("Index","Conta");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Erro()
        {
            return View();
        }
    }
}