using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aptitud.SwetuggMob.Web.Services;
using Nancy;
using Nancy.Routing;

namespace Aptitud.SwetuggMob.Web.Modules
{
    public class LocationModule : NancyModule
    {
        public LocationModule()
        {
            var finder = new TweetFinder();

            var locations = finder.GetMockedLocations();

            Get["/api/locations"] = parameters => Response.AsJson(locations);
        }
    
    }
}