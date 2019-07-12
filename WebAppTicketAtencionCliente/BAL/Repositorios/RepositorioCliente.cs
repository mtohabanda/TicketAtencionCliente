using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using BAL.Modelos;
using DAL;

namespace BAL.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        public void RegistrarCliente(ClienteModelo clienteModelo)
        {
            using (var db = new db_Tickek_AtencionClienteEntities())
            {
                db.Cliente.Add(MapearABaseDeDatos(clienteModelo));
                db.SaveChanges();
            }
        }

        public Cliente MapearABaseDeDatos(ClienteModelo clienteModelo) {
            return new Cliente()
            {
                Id = clienteModelo.Id,
                Nombres = clienteModelo.Nombres
            };
        }

        public ClienteModelo MapearAAplicacion(Cliente cliente) {
            return new ClienteModelo()
            {
                Id = cliente.Id,
                Nombres = cliente.Nombres
            };
        }

        public ClienteModelo ObtenerClienteModeloConMaxId()
        {
            using (var db = new db_Tickek_AtencionClienteEntities())
            {
                return db.Cliente.Where(c => c.Id == db.Cliente.Max(m => m.Id))
                                 .Select(MapearAAplicacion).SingleOrDefault();
            }
        }
    }
}
