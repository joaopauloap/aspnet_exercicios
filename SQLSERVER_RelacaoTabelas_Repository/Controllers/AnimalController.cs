using CRUD_SQLSERVER.Models;
using CRUD_SQLSERVER.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRUD_SQLSERVER.Controllers
{
    public class AnimalController : Controller
    {
        private IAnimalRepository _animalRepository;
        private IVeterinarioRepository _veterinarioRepository;
        private IPlanoRepository _planoRepository;
        private IAnimalVeterinarioRepository _animalVeterinarioRepository;

        public AnimalController(IAnimalRepository animalRepository, IVeterinarioRepository veterinarioRepository, IPlanoRepository planoRepository, IAnimalVeterinarioRepository animalVeterinarioRepository)
        {
            _animalRepository = animalRepository;   
            _veterinarioRepository = veterinarioRepository;
            _planoRepository = planoRepository;
            _animalVeterinarioRepository = animalVeterinarioRepository;
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
            var planos = _planoRepository.BuscarPor(p => p.Disponivel == true);
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
            var planos = _planoRepository.BuscarPor(p => p.Disponivel == true);
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

            var veterinarios = _veterinarioRepository.Listar();
            ViewBag.veterinarios = new SelectList(veterinarios, "VeterinarioId","Nome");
            ViewBag.consultas = _animalVeterinarioRepository.BuscarPor(av => av.AnimalId == id);
            return View(animal);

        }

        [HttpPost]
        public IActionResult AgendarConsulta(AnimalVeterinario consulta)
        {
            _animalVeterinarioRepository.Cadastrar(consulta);
            _animalVeterinarioRepository.Salvar();
            TempData["msg"] = "Consulta agendada com sucesso.";
            return RedirectToAction("Consultas", new {id=consulta.AnimalId});
        }
    }
}
