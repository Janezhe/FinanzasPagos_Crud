using FinanzasPagos_Crud.Data;
using FinanzasPagos_Crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasPagos_Crud.Controllers
{
    public class GastosController : Controller
    {
        private readonly FinanzasDb _db;
        public GastosController(FinanzasDb db) => _db = db;

        [HttpPost]
        public IActionResult Guardar(Gasto g)
        {
            g.CreadoEn = DateTime.UtcNow;
            _db.Gastos.Add(g);
            _db.SaveChanges();
            TempData["Exito"] = "Gasto registrado correctamente.";
            TempData["Seccion"] = "gastos";
            return RedirectToAction("Index", "Pagos");
        }

        [HttpPost]
        public IActionResult Actualizar(Gasto g)
        {
            var exist = _db.Gastos.Find(g.Id);
            if (exist != null)
            {
                exist.Monto = g.Monto;
                exist.Descripcion = g.Descripcion;
                _db.SaveChanges();
                TempData["Exito"] = "Gasto actualizado correctamente.";
                TempData["Seccion"] = "gastos";
            }
            return RedirectToAction("Index", "Pagos");
        }

        [HttpPost]
        public IActionResult Borrar(int Id)
        {
            var exist = _db.Gastos.Find(Id);
            if (exist != null)
            {
                _db.Gastos.Remove(exist);
                _db.SaveChanges();
            }
            TempData["Exito"] = "Gasto eliminado correctamente.";
            TempData["Seccion"] = "gastos";
            return RedirectToAction("Index", "Pagos");
        }
    }
}