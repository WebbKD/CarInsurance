using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarInsuranceClaim.Startup))]
namespace CarInsuranceClaim
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
