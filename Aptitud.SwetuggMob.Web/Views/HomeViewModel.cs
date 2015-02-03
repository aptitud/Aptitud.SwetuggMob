using System.Collections.Generic;
using System.Linq;
using Tweetinvi.Core.Interfaces;

namespace Aptitud.SwetuggMob.Web.Views
{
    public class HomeViewModel
    {
        public Dictionary<string, Geocoding.Location> TweetLocations { get; set; }

        public static HomeViewModel Create(Dictionary<string, Geocoding.Location> locations)
        {
            return new HomeViewModel
            {
                TweetLocations = locations
            };
        }
    }
}