using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del producto")]
        [Display(Name = "Nombre del Producto")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la descripción del producto")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese el precio del producto")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Ingrese la categoría del producto")]
        public string? Categoria { get; set; }

        [Required(ErrorMessage = "Ingrese la marca del producto")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "Ingrese la talla del producto")]
        public string? Talla { get; set; }

        [Required(ErrorMessage = "Ingrese el color del producto")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Ingrese el stock del producto")]
        public int Stock { get; set; }
    }
}
