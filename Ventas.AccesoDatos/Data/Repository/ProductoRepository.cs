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
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Producto producto)
        {
            var objDesdeDb = _db.Producto.FirstOrDefault(s => s.ProductoId == producto.ProductoId);
            objDesdeDb.Nombre = producto.Nombre;
            objDesdeDb.Descripcion = producto.Descripcion;
            objDesdeDb.Precio = producto.Precio;
            objDesdeDb.Categoria = producto.Categoria;
            objDesdeDb.Marca = producto.Marca;
            objDesdeDb.Talla = producto.Talla;
            objDesdeDb.Color = producto.Color;
            objDesdeDb.Stock = producto.Stock;

            //_db.SaveChanges();
        }

    }
}
