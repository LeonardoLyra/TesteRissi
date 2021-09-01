using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste_Rissi.Data;
using Teste_Rissi.Models;

namespace Teste_Rissi.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(IFormCollection cliente)
        {
            string nome = cliente["Nome"];
            string email = cliente["Email"];
            string senha = cliente["Senha"];

            if (nome.Length < 6)
            {
                ViewBag.Mensagem = "Nome deve conter 6 ou mais carecteres";
            }
            if (!email.Contains("@"))
            {
                ViewBag.Mensagem = "Email inválido";
                return View();
            }
            if (senha.Length < 6)
            {
                ViewBag.Mensagem = "Senha deve conter 6 caracteres ou mais";
                return View();
            }

            var novoCliente = new Cliente();
            novoCliente.Nome = cliente["nome"];
            novoCliente.Email = cliente["email"];
            novoCliente.Senha = cliente["senha"];

            using (var data = new ClienteData())
                data.Create(novoCliente);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View(new ClienteViewModel());
        }

        [HttpPost]
        public IActionResult Login(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (var data = new ClienteData())
            {
                var user = data.Read(model);

                if (user == null)
                {
                    ViewBag.Message = "Email e/ou senha incorretos!";
                    return View(model);
                }

                HttpContext.Session.SetString("user", JsonSerializer.Serialize<Cliente>(user));

                return RedirectToAction("Index", "Carro");
            }
        }

        [HttpGet]
        public IActionResult Sair()
        {

            HttpContext.Session.Remove("user");

            return RedirectToAction("Login", "Cliente");

        }
        
    }
}