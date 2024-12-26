using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Ventas.AccesoDatos.Data.Repository.IRepository;
using Ventas.Models;

namespace Ventas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VentasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public VentasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            var ventas = _contenedorTrabajo.ventas.GetAll(includeProperties: "DetallesVenta,Cliente").OrderByDescending(v => v.Fecha);

            return View(ventas);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Usando GetAll con filtro e includeProperties (¡CORRECTO!)
            var venta = _contenedorTrabajo.ventas.GetAll(
                filter: v => v.VentaId == id, // Filtra por el ID de la venta
                includeProperties: "DetallesVenta.Producto,Cliente" // Incluye las propiedades relacionadas
            ).FirstOrDefault(); // Obtiene la primera venta que coincide (o null si no hay ninguna)

            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }


        public IActionResult Create()
        {
            var venta = new Venta();
            // Usar SelectList para pasar las listas al DropDownList
            ViewData["ClienteId"] = new SelectList(_contenedorTrabajo.cliente.GetAll(), "ClienteId", "Nombre");
            ViewData["ProductoId"] = new SelectList(_contenedorTrabajo.producto.GetAll(), "ProductoId", "Nombre");
            return View(venta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venta venta, int[] productoIds, int[] cantidades)
        {
            if (productoIds != null && cantidades != null && productoIds.Length == cantidades.Length)
            {
                venta.DetallesVenta = new List<DetalleVenta>();
                for (int i = 0; i < productoIds.Length; i++)
                {
                    var producto = _contenedorTrabajo.producto.Get(productoIds[i]);
                    if (producto != null)
                    {
                        var detalle = new DetalleVenta
                        {
                            ProductoId = productoIds[i],
                            Cantidad = cantidades[i],
                            PrecioUnitario = producto.Precio // Assign retrieved price here
                        };
                        detalle.CalcularSubtotal();
                        venta.DetallesVenta.Add(detalle);
                    }
                }
                venta.CalcularTotal();

                if (ModelState.IsValid)
                {
                    _contenedorTrabajo.ventas.Add(venta);
                    _contenedorTrabajo.Save(); // Guarda los cambios en la base de datos
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["ClienteId"] = new SelectList(_contenedorTrabajo.cliente.GetAll(), "ClienteId", "Nombre", venta.ClienteId);
            ViewData["ProductoId"] = new SelectList(_contenedorTrabajo.producto.GetAll(), "ProductoId", "Nombre");
            return View(venta);
        }

    }
}
