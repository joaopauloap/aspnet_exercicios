using CRUD_SQLSERVER.Models;
using CRUD_SQLSERVER.Persistence;
using CRUD_SQLSERVER.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRUD_SQLSERVER.Controllers
{
    public class AnimalController : Controller
    {
        private PetShopContext _context;    //o ideal é ser totalmente substituido pelo repositorys
        private IAnimalRepository _animalRepository;

        public AnimalController(PetShopContext context, IAnimalRepository animalRepository)
        {
            _context = context;
            _animalRepository = animalRepository;   
        }

        public IActionResult Index(string nomeBusca)
        {
            //List<Animal> animais = _context.Animais.Where(a => a.Nome.Contains(nomeBusca) || nomeBusca == null).Include(a => a.Plano).ToList();
            var animais = _animalRepository.BuscarPor(a => a.Nome.Contains(nomeBusca) || nomeBusca == null);
            return View(animais);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            List<Plano> planos = _context.Planos.Where<Plano>(p => p.Disponivel == true).ToList();
            ViewBag.planos = new SelectList(planos, "PlanoId", "Nome");
            ViewBag.planos = new SelectList(planos, "PlanoId", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Animal animal)
        {
            //_context.Animais.Add(animal);
            _animalRepository.Cadastrar(animal);
            //_context.SaveChanges();
            _animalRepository.Salvar();
            TempData["msg"] = "Animal cadastrado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            List<Plano> planos = _context.Planos.Where<Plano>(p => p.Disponivel == true).ToList();
            ViewBag.planos = new SelectList(planos, "PlanoId", "Nome");

            //Animal animal = _context.Animais.Find(id);
            Animal animal = _animalRepository.BuscarPorId(id);
            return View(animal);
        }

        [HttpPost]
        public IActionResult Editar(Animal animal)
        {
            //_context.Animais.Update(animal);
            _animalRepository.Atualizar(animal);
            //_context.SaveChanges();
            _animalRepository.Salvar();
            TempData["msg"] = "Animal editado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            //Animal animal = _context.Animais.Find(id);
            //_context.Animais.Remove(animal);
            _animalRepository.Remover(id);
            //_context.SaveChanges();
            _animalRepository.Salvar();
            TempData["msg"] = "Animal removido com sucesso";
            return RedirectToAction("Index");
        }

        public IActionResult Consultas(int id)
        {
            //Animal animal = _context.Animais.Include(a => a.Plano).Where(a => a.AnimalId == id).FirstOrDefault();
            Animal animal = _animalRepository.BuscarPorId(id);

            List<Veterinario> veterinarios = _context.Veterinarios.ToList();
            ViewBag.veterinarios = new SelectList(veterinarios, "VeterinarioId","Nome");
            ViewBag.consultas = _context.AnimaisVeterinarios.Where(av => av.AnimalId == id).ToList();
            return View(animal);

        }

        [HttpPost]
        public IActionResult AgendarConsulta(AnimalVeterinario consulta)
        {
            _context.AnimaisVeterinarios.Add(consulta);
            _context.SaveChanges();
            TempData["msg"] = "Consulta agendada com sucesso.";
            return RedirectToAction("Consultas", new {id=consulta.AnimalId});
        }
    }
}
