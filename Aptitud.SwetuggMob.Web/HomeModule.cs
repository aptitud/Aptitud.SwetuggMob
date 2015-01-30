using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace Aptitud.SwetuggMob.Web
{
    public class HomeModule : NancyModule
    {
        public HomeModule() {
            Get["/"] = parameters => "Hello Swetugg";
        }
    }
}