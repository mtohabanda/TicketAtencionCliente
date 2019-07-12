using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Modelos
{
  public  class ColaClienteModelo
    {
        public int IdCola { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string EstadoAtencion { get; set; }
    }
}
