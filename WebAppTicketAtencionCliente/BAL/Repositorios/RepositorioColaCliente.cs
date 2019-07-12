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
    public class RepositorioColaCliente : IRepositorioColaCliente
    {
        public int ObtenerIdColaAAsignarAlCliente()
        {
            using (var db = new db_Tickek_AtencionClienteEntities())
            {
                var idColaVacia = ObtenerUnaColaVacia();
                int idColaMinimaDeClientes = ObtenerColaMinimaDeClientes();
                return idColaVacia > 0 ? idColaVacia : idColaMinimaDeClientes > 0 ? idColaMinimaDeClientes : ObtenerIdColaConTiempoDuracionMininaEnAtencionAlCliente();
                
            }
        }

        public int ObtenerUnaColaVacia() {
            using (var db = new db_Tickek_AtencionClienteEntities())
            {
                var colaAAsignar = (from co in db.Cola
                                    join cc in db.ColaCliente on co.IdCola equals cc.IdCola into ccli
                                    from cvg in ccli.DefaultIfEmpty()
                                    group cvg by new { co.IdCola } into cvg
                                    let contarCliente = cvg.Sum( cv => cv!=null ? 1: 0)
                                    where contarCliente == 0
                                    orderby contarCliente ascending
                                    select new { cvg.Key.IdCola}).ToList();
                return colaAAsignar.Count()>1 ? 0 : colaAAsignar.Count()!=0 ? colaAAsignar.SingleOrDefault().IdCola : 0;                
            }
        }

        public int ObtenerColaMinimaDeClientes() {
            using (var db = new db_Tickek_AtencionClienteEntities()) 
            {
                int totalNumeroDeClienteMinimo = ObtenerTotalDeNumerosDeClientesMinimoDeUnaCola();
                if (totalNumeroDeClienteMinimo > 0)
                {
                    var listaIdsConClienteMinimo = (from cm in db.Cola
                                                    join ccm in db.ColaCliente on cm.IdCola equals ccm.IdCola into colaMinina
                                                    from cmg in colaMinina.DefaultIfEmpty()
                                                    group cmg by new { cmg.IdCola } into cmg
                                                    let totalClientes = cmg.Sum(cli => cli != null ? 1 : 0)
                                                    where totalClientes == totalNumeroDeClienteMinimo
                                                    select new { IdCola = cmg.Key.IdCola });
                     return listaIdsConClienteMinimo.Count() > 1? 0:listaIdsConClienteMinimo.Select(x=>x.IdCola).SingleOrDefault();
                }
                else
                    return 0; 
            }
        }

        public int ObtenerTotalDeNumerosDeClientesMinimoDeUnaCola() {
            using (var db = new db_Tickek_AtencionClienteEntities())
            {
                return
                        ((from c in db.Cola
                          join cc in db.ColaCliente on c.IdCola equals cc.IdCola into colaCliente
                          from ccg in colaCliente.DefaultIfEmpty()
                          group ccg by new { c.IdCola } into ccg
                          let contarCliente = ccg.Sum(x => x != null ? 1 : 0)
                          select new { ContarCliente = contarCliente })).Min(m => m.ContarCliente);
            }
        }

        public int ObtenerIdColaConTiempoDuracionMininaEnAtencionAlCliente()
        {
            using (var db = new db_Tickek_AtencionClienteEntities())
            {
                return  (from co in db.Cola
                        where co.TiempoDuracionAtencion == db.Cola.Min(c => c.TiempoDuracionAtencion)
                        select new { co.IdCola }).SingleOrDefault().IdCola;                        
                      
            }
        }

        public List<ColaClienteModelo> AgruparClientesPorCola()
        {
            using (var db = new db_Tickek_AtencionClienteEntities())
            {
                return (from c in db.Cola
                        join cc in db.ColaCliente on c.IdCola equals cc.IdCola
                        join cli in db.Cliente on cc.IdCliente equals cli.Id
                        orderby c.IdCola, cc.IdCliente
                        where cc.EstadoAtencion == "N"
                        select new ColaClienteModelo
                           {
                               IdCliente = cc.IdCliente,
                               IdCola = cc.IdCola,
                               NombreCliente = cc.IdCliente+"-"+cli.Nombres,
                               EstadoAtencion = cc.EstadoAtencion
                           }).ToList();
            }
        }

        public ColaClienteModelo MapearAAplicacion(ColaCliente colaCliente) {
            return new ColaClienteModelo()
            {
                IdCola = colaCliente.IdCola,
                IdCliente = colaCliente.IdCliente,
                EstadoAtencion = colaCliente.EstadoAtencion
            };
        }

        public ColaCliente MapearABaseDeDatos(ColaClienteModelo colaClienteModelo) {
            return new ColaCliente()
            {
                IdCola = colaClienteModelo.IdCola,
                IdCliente = colaClienteModelo.IdCliente,
                EstadoAtencion = colaClienteModelo.EstadoAtencion
            };
        }

        public void AsignarClienteAUnaCola(ColaClienteModelo colaClienteModelo)
        {
            using (var db = new db_Tickek_AtencionClienteEntities())
            {
                db.ColaCliente.Add(MapearABaseDeDatos(colaClienteModelo));
                db.SaveChanges();
            }
        }
    }
}
