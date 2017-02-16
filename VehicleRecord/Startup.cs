using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleRecord.Startup))]
namespace VehicleRecord
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
