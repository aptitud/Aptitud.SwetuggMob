using Aptitud.SwetuggMob.Web.Services;
using Nancy;

namespace Aptitud.SwetuggMob.Web.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters => View["Home.html"];
        }
    }
}