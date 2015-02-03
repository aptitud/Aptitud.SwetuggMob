using Aptitud.SwetuggMob.Web.Services;
using Nancy;

namespace Aptitud.SwetuggMob.Web.Modules
{
    public class LocationModule : NancyModule
    {
        public LocationModule()
        {
            var finder = new TweetFinder();

            var locations = finder.GetLocationsForHashTag("#SweTugg");

            Get["/api/locations"] = parameters => Response.AsJson(locations);
        }
    
    }
}