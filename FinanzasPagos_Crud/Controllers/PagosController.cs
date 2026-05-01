using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanzasPagos_Crud.Models;
using FinanzasPagos_Crud.Data;

namespace FinanzasPagos_Crud.Controllers
{
    public class PagosController : Controller
    {
        private readonly FinanzasDb _context;
        public PagosController(FinanzasDb context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var vm = new PagoGastoViewModel
            {
                Pagos = await _context.Pagos.OrderByDescending(p => p.Id).ToListAsync(),
                Gastos = await _context.Gastos.OrderByDescending(g => g.Id).ToListAsync()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar([FromForm] string Monto, [FromForm] string Estado)
        {
            if (decimal.TryParse(Monto, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal monto))
            {
                var pago = new Pago
                {
                    Monto = monto,
                    Estado = Enum.Parse<EstadoPago>(Estado),
                    Categoria = CategoriaPago.Pago,   // valor fijo, columna se conserva en BD
                    CreadoEn = DateTime.UtcNow
                };
                _context.Pagos.Add(pago);
                await _context.SaveChangesAsync();
                TempData["Exito"] = "Pago guardado correctamente.";
            }
            return RedirectToAction("Index", "Pagos");
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar([FromForm] int Id, [FromForm] string Monto, [FromForm] string Estado)
        {
            var pago = await _context.Pagos.FindAsync(Id);
            if (pago != null && decimal.TryParse(Monto, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal monto))
            {
                pago.Monto = monto;
                pago.Estado = Enum.Parse<EstadoPago>(Estado);
                // Categoria no se toca
                await _context.SaveChangesAsync();
                TempData["Exito"] = "Pago actualizado correctamente.";
            }
            return RedirectToAction("Index", "Pagos");
        }

        [HttpPost]
        public async Task<IActionResult> Borrar([FromForm] int Id)
        {
            var pago = await _context.Pagos.FindAsync(Id);
            if (pago != null)
            {
                _context.Pagos.Remove(pago);
                await _context.SaveChangesAsync();
                TempData["Exito"] = "Pago eliminado correctamente.";
            }
            return RedirectToAction("Index", "Pagos");
        }
    }
}