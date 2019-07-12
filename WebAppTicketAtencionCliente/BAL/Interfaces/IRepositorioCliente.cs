﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Modelos;

namespace BAL.Interfaces
{
  public  interface IRepositorioCliente
    {
        void RegistrarCliente(ClienteModelo clienteModelo);
        ClienteModelo ObtenerClienteModeloConMaxId();

    }
}