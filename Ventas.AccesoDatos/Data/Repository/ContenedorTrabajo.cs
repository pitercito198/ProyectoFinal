using Ventas.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.AccesoDatos.Data.Repository.IRepository;
using Ventas.AccesoDato.Data;



namespace Ventas.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _context;
        public ContenedorTrabajo(ApplicationDbContext context)
        {
            _context = context;
            //se agregan cada uno de los repositorios para que queden encapsulados
            producto = new ProductoRepository(_context);
            cliente = new ClienteRepository(_context);
            ventas = new VentaRepository(_context);
            detalleVenta = new DetalleVentasRepository(_context);
        }

        public IProductoRepository producto { get; private set; }
        public IClienteRepository cliente { get; private set; }
        public IVentasRepository ventas { get; private set; }
        public IDetalleVentaRepository detalleVenta { get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
