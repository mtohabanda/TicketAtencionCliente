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
    public class RepositorioCola : IRepositorioCola
    {
        public List<ColaModelo> ObtenerColasDeATencionACliente()
        {
            using (var db = new db_Tickek_AtencionClienteEntities())
            {
                return db.Cola.Select(MapearAAplicacion).ToList();
            }
        }

        public int ObtenerTiempoDeDuracionAtencion(int idCola)
        {
            using (var db = new db_Tickek_AtencionClienteEntities())
            {
                return db.Cola.Where(x => x.IdCola == idCola)
                              .Select(x => x.TiempoDuracionAtencion).SingleOrDefault();
            }
        }

        public ColaModelo MapearAAplicacion(Cola cola) {
            return new ColaModelo()
            {
                IdCola = cola.IdCola,
                Nombre = cola.Nombre,
                TiempoDuracionAtencion = cola.TiempoDuracionAtencion
            };
        }
        
    }
}
