using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Modelos;

namespace BAL.Interfaces
{
  public  interface IRepositorioColaCliente
    {
        int ObtenerIdColaAAsignarAlCliente();
        List<ColaClienteModelo> AgruparClientesPorCola();
        void AsignarClienteAUnaCola(ColaClienteModelo colaClienteModelo);
    }
}
