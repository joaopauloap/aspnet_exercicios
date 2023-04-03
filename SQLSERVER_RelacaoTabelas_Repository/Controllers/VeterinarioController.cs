using CRUD_SQLSERVER.Models;
using CRUD_SQLSERVER.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_SQLSERVER.Controllers
{
    public class VeterinarioController : Controller
    {
        private IVeterinarioRepository _veterinarioRepository;
        public VeterinarioController(IVeterinarioRepository veterinarioRepository)
        {
            _veterinarioRepository = veterinarioRepository;
        }
        public IActionResult Index()
        {
            var veterinarios = _veterinarioRepository.Listar();
            return View(veterinarios);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Veterinario veterinario)
        {
           _veterinarioRepository.Cadastrar(veterinario);
            _veterinarioRepository.Salvar();
            TempData["msg"] = "Veterinario cadastrado com sucesso!";
            return RedirectToAction("Index");
        }
    }
}
