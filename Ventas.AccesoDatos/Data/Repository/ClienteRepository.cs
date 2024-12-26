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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly ApplicationDbContext _db;

        public ClienteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Cliente cliente)
        {
            var objDesdeDb = _db.Cliente.FirstOrDefault(s => s.ClienteId == cliente.ClienteId);
            objDesdeDb.CI = cliente.CI;
            objDesdeDb.Nombre = cliente.Nombre;
            objDesdeDb.Apellido = cliente.Apellido;
            objDesdeDb.Email = cliente.Email;
            objDesdeDb.Telefono = cliente.Telefono;
            objDesdeDb.Direccion = cliente.Direccion;


            //_db.SaveChanges();
        }
    }
}
