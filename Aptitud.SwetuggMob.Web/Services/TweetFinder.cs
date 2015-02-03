using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Geocoding;
using Tweetinvi;
using Tweetinvi.Core.Events;
using Tweetinvi.Core.Interfaces;
using Geocoding.Google;

namespace Aptitud.SwetuggMob.Web.Services
{
    public class TweetFinder
    {
        public Lazy<TwitterStartup> Startup = new Lazy<TwitterStartup>(() => new TwitterStartup());

        public TweetFinder()
        {
            var startup = Startup.Value;
        }

        public IEnumerable<ITweet> GetTweetsForHashTag(string hashTag)
        {
            var searchParams = Search.GenerateSearchTweetParameter(hashTag);
            searchParams.MaximumNumberOfResults = 15;

            return Search.SearchTweets(searchParams);
        }

        public List<TweetLocation> GetMockedLocations()
        {
            var locations = new List<TweetLocation>()
            {
                new TweetLocation() { Name = "Stockholm, Sweden", Lat = 59.3293235, Long = 18.0685808 },
                new TweetLocation() { Name = "Sundsvall, Sweden", Lat = 62.390811, Long = 17.306927 },
                new TweetLocation() { Name = "Värmdö, Sweden", Lat = 59.333333, Long = 18.383333 },
                new TweetLocation() { Name = "Oslo, Norway", Lat = 59.9138688, Long = 10.7522454 },
                new TweetLocation() { Name = "Bandung City, Bandung City, West Java, Indonesia", Lat = -6.9148644, Long = 107.6082421 },
                new TweetLocation() { Name = "Gothenburg, Sweden", Lat = 57.70887, Long = 11.97456 }
            };

            return locations;
        } 

        public Dictionary<string, Geocoding.Location> GetLocationsForHashTag(string hashTag)
        {
            var tweets = GetTweetsForHashTag("#Swetugg");
            var locations = GetDistinctLocationsFromTweets(tweets);
            var geoCodes = locations.Select(GetGeocode).Where(geoCode => geoCode != null).ToList();

            var groupedAddresses = geoCodes.GroupBy(x => x.FormattedAddress);
            return groupedAddresses.ToDictionary(x => x.Key, x => x.First().Coordinates);
        }

        public IEnumerable<string> GetDistinctLocationsFromTweets(IEnumerable<ITweet> tweets)
        {
            return tweets.Where(t => !String.IsNullOrEmpty(t.Creator.Location))
                .Select(tweet => tweet.Creator.Location).ToList().Distinct();
        }

        public Geocoding.Google.GoogleAddress GetGeocode(string address)
		{
			if (String.IsNullOrEmpty(address))
                return null;

            var geoCoder = new Geocoding.Google.GoogleGeocoder();

			return geoCoder.Geocode(address).FirstOrDefault();
		}
    }


    public class TwitterStartup
    {
        public TwitterStartup()
        {
            TwitterCredentials.SetCredentials(
                ConfigurationManager.AppSettings["tw.accessToken"],
                ConfigurationManager.AppSettings["tw.accessSecret"],
                ConfigurationManager.AppSettings["tw.consumerKey"],
                ConfigurationManager.AppSettings["tw.consumerSecret"]
                );
        }
    }
}