using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        IProductoRepository producto { get; }
        IClienteRepository cliente { get; }
        IVentasRepository ventas { get; }
        IDetalleVentaRepository detalleVenta { get; }
        void Save();
    }

}
