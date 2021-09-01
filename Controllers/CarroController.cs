using Teste_Rissi.Data;
using Teste_Rissi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Teste_Rissi.Controllers
{
    public class CarroController : Controller
    {
        
        public IActionResult Index()
        {
            using (var data = new CarroData())
                return View(data.Read());
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            using (var data = new CarroData())
                ViewBag.Categorias = data.Read();

            return View();
        }


        [HttpPost]
        public IActionResult Create(Carro carro)
        {
            
            if (!ModelState.IsValid)
            {
                return View(carro);
            }

            using (var data = new CarroData())
                data.Create(carro);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using (var data = new CarroData())
            {
                if (data.Delete(id))
                {
                    TempData["exclusaoSucesso"] = "A Exclusão foi realizada com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["exclusaoErro"] = "A Exclusão falhou, pode haver algo atrelado com o ID deste carro";
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (var data = new CarroData())
            {
                var lista = data.Read();
                var item = new SelectList(lista, "IdCategoria", "Nome");
                ViewBag.Categorias = item;
            }

            using (var data = new CarroData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Carro carro)
        {
            carro.IdCarro = id;

            if (!ModelState.IsValid)
            {
                return View(carro);
            }

            using (var data = new CarroData())
                data.Update(carro);

            return RedirectToAction("Index");
        }
    }
}