using Ventas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.AccesoDatos.Data.Repository.IRepository
{
    public interface IVentasRepository : IRepository<Venta>
    {
        void Update(Venta venta);
    }
}
