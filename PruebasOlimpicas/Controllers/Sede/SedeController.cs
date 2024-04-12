using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebasOlimpicas.Data.Sede;
using PruebasOlimpicas.Models.Sede;

namespace PruebasOlimpicas.Controllers.Sede
{
    public class SedeController : Controller
    {
        SedeData _SedeData = new SedeData();

        public ActionResult ListarSedesJson()
        {
            var sedes = ListarSedes();
            return Json(sedes);
        }

        public IActionResult ListarSedes()
        {
            var ListaSede = _SedeData.ListarSedes();

            return View(ListaSede);
        }

        public IActionResult GuardarSede()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarSede(SedeModel Sede)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _SedeData.GuardarSede(Sede);

            if (respuesta)
                return RedirectToAction("ListarSedes");
            else
                return View();
        }

        public IActionResult EditarSede(int IdSede)
        {
            var sede = _SedeData.ObtenerSede(IdSede);
            return View(sede);
        }

        [HttpPost]
        public IActionResult EditarSede(SedeModel sede)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _SedeData.EditarSede(sede);

            if (respuesta)
                return RedirectToAction("ListarSedes");
            else
                return View();
        }

        public IActionResult EliminarSede(int IdSede)
        {
            var sede = _SedeData.ObtenerSede(IdSede);
            return View(sede);
        }

        [HttpPost]
        public IActionResult EliminarSede(SedeModel sede)
        {
            var respuesta = _SedeData.EliminarSede(sede.IdSede);

            if (respuesta)
                return RedirectToAction("ListarSedes");
            else
                return View();
        }

    }
}
