using System.Web.Mvc;
using BAL.Modelos;
using BAL.Interfaces;
using BAL.Repositorios;
using DAL;

namespace WebAppTicketAtencionCliente.Areas.TicketAtencionCliente.Controllers
{
    public class ClienteController : Controller
    {
        const string CLIENTE_NO_ATENTIDO = "N";
        private IRepositorioCliente _repositorioCliente;
        private IRepositorioColaCliente _repositorioColaCliente;

        public ClienteController()
        {
            if (_repositorioCliente == null && _repositorioColaCliente == null) {
                _repositorioCliente = new RepositorioCliente();
                _repositorioColaCliente = new RepositorioColaCliente();
            }
        }

      
        public ActionResult AddCliente() {
            return View(new ClienteModelo());
        }

        [HttpPost]
        public ActionResult AddCliente(ClienteModelo clienteModelo) {
            using (var db = new db_Tickek_AtencionClienteEntities())
            {
                if (clienteModelo.Nombres!=null)
                {
                    _repositorioCliente.RegistrarCliente(clienteModelo);
                    return RedirectToAction("/AsignarClienteAUnaCola");
                }
                else
                {
                    return View();
                }
            }
        }

        public ActionResult AsignarClienteAUnaCola()
        {
            SetViewBagConUltimoClienteCreado();
            return View(_repositorioColaCliente.AgruparClientesPorCola());
        }

        [HttpPost]
        public ActionResult AsignarClienteAUnaCola(ColaClienteModelo colaClienteModelo)
        {
            if(ViewBag.ClienteAsignar == null) { 
                SetViewBagConUltimoClienteCreado();
                InsertarClienteAUnaCola();
            }
            ViewBag.ClienteAsignar = new ClienteModelo();
            
            return View(_repositorioColaCliente.AgruparClientesPorCola());
        }

        private void InsertarClienteAUnaCola() {
            ColaClienteModelo objColaClienteModelo = new ColaClienteModelo();
            objColaClienteModelo.IdCliente = ViewBag.ClienteAsignar.Id;
            objColaClienteModelo.IdCola = _repositorioColaCliente.ObtenerIdColaAAsignarAlCliente();
            objColaClienteModelo.EstadoAtencion = CLIENTE_NO_ATENTIDO;
            _repositorioColaCliente.AsignarClienteAUnaCola(objColaClienteModelo);
        }

        private void SetViewBagConUltimoClienteCreado() {

            ClienteModelo ultimoClienteCreado = _repositorioCliente.ObtenerClienteModeloConMaxId();
            ViewBag.ClienteAsignar = ultimoClienteCreado;
        }


    }
}