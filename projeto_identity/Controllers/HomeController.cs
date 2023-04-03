using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projeto_identity.Areas.Identity.Data;
using projeto_identity.Models;
using System.Diagnostics;

namespace projeto_identity.Controllers
{
    [Authorize] //Precisa estar logado para acessar
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProjetoBancoContext _context;
        private UserManager<Cliente> _userManager;

        public HomeController(ILogger<HomeController> logger, ProjetoBancoContext context, UserManager<Cliente> userManager)
        {
            _logger = logger;
            _context = context;
            userManager = _userManager;
        }

        //[Authorize] //Precisa estar logado para acessar
        public IActionResult Index()
        {
            Cliente clienteLogado = _context.Clientes.Find(_userManager.GetUserId(User));
            return View(clienteLogado);
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
    }
}