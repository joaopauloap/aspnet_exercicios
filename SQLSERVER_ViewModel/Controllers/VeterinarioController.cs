using CRUD_SQLSERVER.Models;
using CRUD_SQLSERVER.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_SQLSERVER.Controllers
{
    public class VeterinarioController : Controller
    {
        private PetShopContext _context;
        public VeterinarioController(PetShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Veterinario> veterinarios = _context.Veterinarios.Include(v => v.ContratoTrabalho).ToList();
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
            if (veterinario.ContratoTrabalho.Valor < 1200)
            {
                ModelState.AddModelError("ContratoTrabalho.Valor", "O valor de contrato não pode ser menor que R$ 1200,00");
            }

            if (ModelState.IsValid)
            {
                _context.Veterinarios.Add(veterinario);
                _context.SaveChanges();
                TempData["msg"] = "Veterinario cadastrado com sucesso!";
                return RedirectToAction("Cadastrar");

            }
            return View();
        }
    }
}
