using Microsoft.AspNetCore.Mvc;
using PruebasOlimpicas.Data.ComplejoDeportivo;
using PruebasOlimpicas.Data.Sede;
using PruebasOlimpicas.Models.ComplejoDeportivo;

namespace PruebasOlimpicas.Controllers.ComplejoDeportivo
{
    public class ComplejoDeportivoController : Controller
    {
        ComplejoDeportivoData _ComplejoDeportivoData = new ComplejoDeportivoData();
        public ActionResult Index()
        {
            SedeData _SedeData = new SedeData();
            var ListaSede = _SedeData.ListarSedes();
            ViewBag.ListaSede = ListaSede;
            return View();
        }

        public IActionResult ListarComplejoDeportivo()
        {
            var ListaComplejoDeportivo = _ComplejoDeportivoData.ListarComplejoDeport();

            return View(ListaComplejoDeportivo);
        }

        public IActionResult GuardarComplejoDeportivo()
        {
            Index();
            return View();
        }

        [HttpPost]
        public IActionResult GuardarComplejoDeportivo(ComplejoDeportivoModel ComplejoDeportivo)
        {
            if (!ModelState.IsValid)
            {
                Index();
                return View();
            }

            var respuesta = _ComplejoDeportivoData.GuardarComplejoDeport(ComplejoDeportivo);

            if (respuesta)
            {
                return RedirectToAction("ListarComplejoDeportivo");
            }

            else
            {
                Index();
                return View();
            }
        }

        public IActionResult EditarComplejoDeportivo(int IdComplejoDeportivo)
        {
            var compolejoDeport = _ComplejoDeportivoData.ObtenerComplejoDeport(IdComplejoDeportivo);
            Index();
            return View(compolejoDeport);
        }

        [HttpPost]
        public IActionResult EditarComplejoDeportivo(ComplejoDeportivoModel ComplejoDeportivo)
        {
            if (!ModelState.IsValid)
            {
                Index();
                return View();
            }

            var respuesta = _ComplejoDeportivoData.EditarComplejoDeport(ComplejoDeportivo);

            if (respuesta)
            {
                return RedirectToAction("ListarComplejoDeportivo");
            }

            else
            {
                Index();
                return View();
            }
        }

        public IActionResult EliminarComplejoDeportivo(int IdComplejoDeportivo)
        {
            var compolejoDeport = _ComplejoDeportivoData.ObtenerComplejoDeport(IdComplejoDeportivo);
            return View(compolejoDeport);
        }

        [HttpPost]
        public IActionResult EliminarComplejoDeportivo(ComplejoDeportivoModel ComplejoDeportivo)
        {
            var respuesta = _ComplejoDeportivoData.EliminarComplejoDeport(ComplejoDeportivo.IdComplejoDeport);

            if (respuesta)
                return RedirectToAction("ListarComplejoDeportivo");
            else
                return View();
        }
    }
}
