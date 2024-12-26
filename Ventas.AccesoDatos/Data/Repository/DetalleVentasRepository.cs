using Ventas.AccesoDato.Data;
using Ventas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.AccesoDatos.Data.Repository.IRepository;

namespace Ventas.AccesoDatos.Data.Repository
{
    public class DetalleVentasRepository : Repository<DetalleVenta>, IDetalleVentaRepository
    {
        private readonly ApplicationDbContext _db;

        public DetalleVentasRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(DetalleVenta detalleVenta)
        {
            var objDesdeDb = _db.DetalleVenta.FirstOrDefault(s => s.Id == detalleVenta.Id);
            objDesdeDb.VentaId = detalleVenta.VentaId;
            objDesdeDb.ProductoId = detalleVenta.ProductoId;
            objDesdeDb.Cantidad = detalleVenta.Cantidad;
            objDesdeDb.PrecioUnitario = detalleVenta.PrecioUnitario;
            objDesdeDb.Subtotal = detalleVenta.Subtotal;


            _db.SaveChanges();
        }
    }
}
