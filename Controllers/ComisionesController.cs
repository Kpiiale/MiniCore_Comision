using Microsoft.AspNetCore.Mvc;
using MiniCore_Comision.Models;

namespace MiniCore_Comision.Controllers
{
    public class ComisionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComisionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(decimal? minComision)
        {
            var resumen = _context.Vendedores
                .Select(v => new ResumenComisionViewModel
                {
                    NombreVendedor = v.Nombre,
                    TotalVentas = v.Ventas.Sum(venta => venta.Monto)
                })
                .ToList();

            if (minComision.HasValue)
            {
                resumen = resumen
                    .Where(r => r.TotalComision >= minComision.Value)
                    .ToList();
            }

            ViewBag.MinComision = minComision;
            return View(resumen);
        }
    }
}
