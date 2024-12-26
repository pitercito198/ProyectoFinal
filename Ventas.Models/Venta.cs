using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ventas.Models
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha de la venta")]
        public DateTime Fecha { get; set; } = DateTime.Now; // Valor predeterminado

        [Required(ErrorMessage = "Seleccione el cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        public ICollection<DetalleVenta>? DetallesVenta { get; set; } = new List<DetalleVenta>(); // Inicialización

        public decimal Total { get; set; }

        public void CalcularTotal()
        {
            if (DetallesVenta != null && DetallesVenta.Any())
            {
                Total = DetallesVenta.Sum(dv => dv.Subtotal);
            }
            else
            {
                Total = 0;
            }
        }
    }
}
