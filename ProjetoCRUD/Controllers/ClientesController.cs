using ProjetoCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoCRUD.Controllers
{
    public class ClientesController : Controller
    {
        public static List<Cliente> listaClientes = new List<Cliente>();
        public static Cliente objCliente = new Cliente();
        public static int _id;

        public IActionResult Index()
        {
            ViewBag.listaClientes = listaClientes;
            ViewBag.objCliente = objCliente;

            if ((objCliente.Id != 0) && TempData["edicao"] != null)
            {
                return View(objCliente);
            }

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
            TempData["msg"] = "Cliente removido com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            objCliente = listaClientes.Find(objCliente => objCliente.Id == id);
            TempData["edicao"] = "true";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {

            int index = listaClientes.FindIndex(c => c.Id == cliente.Id);

            listaClientes[index] = cliente;
            TempData["msg"] = "Cliente atualizado com sucesso!";
            TempData["edicao"] = null;
            return RedirectToAction("Index");
        }



    }
}
