using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
            searchParams.MaximumNumberOfResults = 100;

            return Search.SearchTweets(searchParams);
        }

        public Dictionary<string, Geocoding.Location> GetLocationsForHashTag(string hashTag)
        {
            var tweets = GetTweetsForHashTag("#Swetugg");
            var locations = GetDistinctLocationsFromTweets(tweets);
            var geoCodes = new List<GoogleAddress>();

            foreach (var location in locations)
            {
                var geoCode = GetGeocode(location);

                if (geoCode != null)
                    geoCodes.Add(geoCode);
            }

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