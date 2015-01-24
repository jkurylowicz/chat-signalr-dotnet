using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatServer.Startup))]
namespace ChatServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
