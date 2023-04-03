using ASP.NET_Exemplo02_Cadastro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Exemplo02_Cadastro.Controllers
{
    public class ClientesController : Controller
    {
        public static List<Cliente> listaClientes = new List<Cliente>();
        public static int _id;

        public IActionResult Index()
        {
            ViewBag.listaClientes = listaClientes;
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            cliente.Id = ++_id;
            listaClientes.Add(cliente);
            TempData["msg"] = "Cliente cadastrado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            listaClientes.RemoveAll(cliente => cliente.Id == id);
            TempData["msgDelete"] = "Cliente removido";
            return RedirectToAction("Index");
        }
    }
}
