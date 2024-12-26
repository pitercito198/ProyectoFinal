using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Models
{
    public class VentaViewModel
    {
        public Venta? Venta { get; set; }
        public List<int>? ProductosSeleccionados { get; set; } // IDs de los productos seleccionados
        public List<Producto>? ProductosDisponibles { get; set; } // Lista de productos para mostrar en la vista
    }
}
