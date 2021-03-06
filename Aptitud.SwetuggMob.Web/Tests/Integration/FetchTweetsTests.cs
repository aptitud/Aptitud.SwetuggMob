﻿using System;
using System.Collections.Generic;
using System.Linq;
using Aptitud.SwetuggMob.Web.Services;
using NUnit.Framework;
using Tweetinvi.Core.Interfaces;
using Geocoding.Google;

namespace Tests.Integration
{
    [TestFixture]
    public class FetchTweetsTests
    {
        [Test, Ignore]
        public void FetchTweetsTest()
        {
            var tweets = GetSwetuggTweets();
            Assert.That(tweets, Is.Not.Null);
            Assert.That(tweets, Is.Not.Empty);
        }

        private static IEnumerable<ITweet> GetSwetuggTweets()
        {
            var finder = new TweetFinder();
            var tweets = finder.GetTweetsForHashTag("#Swetugg");
            return tweets;
        }

        [Test, Ignore]
        public void GetLocationsFromTweets()
        {
            var finder = new TweetFinder();
            var tweets = finder.GetTweetsForHashTag("#Swetugg");
            var locations = finder.GetDistinctLocationsFromTweets(tweets);
            var geoCodes = new List<GoogleAddress>();

            foreach (var location in locations)
            {
                var geoCode = finder.GetGeocode(location);

                if (geoCode != null)
                    geoCodes.Add(geoCode);
            }

            var distinctGeoCodes = geoCodes.ToLookup(x => x.FormattedAddress, (x) => x.Coordinates);
        }




    }
}
