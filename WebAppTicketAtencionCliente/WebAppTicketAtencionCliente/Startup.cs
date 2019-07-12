using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppTicketAtencionCliente.Startup))]
namespace WebAppTicketAtencionCliente
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
