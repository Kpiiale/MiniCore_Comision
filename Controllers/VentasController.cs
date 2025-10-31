using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniCore_Comision.Models;

namespace MiniCore_Comision.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            CargarListaVendedores();
            return View();
        }

        // POST: Ventas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venta venta)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    venta.Fecha = DateTime.Now;

                    _context.Ventas.Add(venta); // DbSet se llama Ventas
                    _context.SaveChanges();

                    TempData["SuccessMessage"] = "Venta registrada correctamente.";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al guardar la venta: " + ex.Message);
                }
            }

            CargarListaVendedores();
            return View(venta);
        }

        private void CargarListaVendedores()
        {
            ViewBag.Vendedores = new SelectList(_context.Vendedores.ToList(), "Id", "Nombre");
        }
    }
}
