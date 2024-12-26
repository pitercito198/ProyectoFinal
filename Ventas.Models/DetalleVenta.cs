using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ventas.Models
{
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Seleccione la venta")]
        public int VentaId { get; set; }

        [ForeignKey("VentaId")] // Clave foránea
        public Venta? Venta { get; set; }

        [Required(ErrorMessage = "Seleccione el producto")]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")] // Clave foránea
        public Producto? Producto { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")] // Validación de rango
        public int Cantidad { get; set; }

        //[Required(ErrorMessage = "Ingrese el precio unitario")] // Se calcula automáticamente
        public decimal PrecioUnitario { get; set; }

        //[Required(ErrorMessage = "Ingrese el subtotal")] // Se calcula automáticamente
        public decimal Subtotal { get; set; }

        public void CalcularSubtotal()
        {
            Subtotal = Cantidad * PrecioUnitario;
        }
    }
}
