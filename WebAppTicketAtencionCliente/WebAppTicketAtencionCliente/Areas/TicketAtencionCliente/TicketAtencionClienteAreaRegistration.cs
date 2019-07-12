using System.Web.Mvc;

namespace WebAppTicketAtencionCliente.Areas.TicketAtencionCliente
{
    public class TicketAtencionClienteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TicketAtencionCliente";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TicketAtencionCliente_default",
                "TicketAtencionCliente/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}