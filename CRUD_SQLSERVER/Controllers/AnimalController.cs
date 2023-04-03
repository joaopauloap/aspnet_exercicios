using CRUD_SQLSERVER.Models;
using CRUD_SQLSERVER.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD_SQLSERVER.Controllers
{
    public class AnimalController : Controller
    {
        private PetShopContext _context;

        public AnimalController(PetShopContext context)
        {
            _context = context;

        }

        public IActionResult Index(string nomeBusca)
        {
            List<Animal> animais = _context.Animais.Where(a=>a.Nome.Contains(nomeBusca)||nomeBusca == null). ToList();
            return View(animais);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Animal animal)
        {
            _context.Animais.Add(animal);
            _context.SaveChanges();
            TempData["msg"] = "Animal cadastrado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Animal animal = _context.Animais.Find(id);
            return View(animal);
        }

        [HttpPost]
        public IActionResult Editar(Animal animal)
        {
            _context.Animais.Update(animal);
            _context.SaveChanges();
            TempData["msg"] = "Animal editado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            Animal animal = _context.Animais.Find(id);
            _context.Animais.Remove(animal);
            _context.SaveChanges();
            TempData["msg"] = "Animal removido com sucesso";
            return RedirectToAction("Index");
        }
    }
}
