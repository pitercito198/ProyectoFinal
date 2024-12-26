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
    public class VentaRepository : Repository<Venta>, IVentasRepository
    {
        private readonly ApplicationDbContext _db;

        public VentaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Venta venta)
        {
            var objDesdeDb = _db.Venta.FirstOrDefault(s => s.VentaId == venta.VentaId);
            objDesdeDb.Fecha = venta.Fecha;
            objDesdeDb.ClienteId = venta.ClienteId;
            objDesdeDb.Total = venta.Total;


            _db.SaveChanges();
        }
    }
}
