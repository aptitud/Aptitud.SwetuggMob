﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Core.Events;
using Tweetinvi.Core.Interfaces;

namespace Aptitud.SwetuggMob.Web.Services
{
    public class TweetFinder
    {
        public Lazy<TwitterStartup> Startup = new Lazy<TwitterStartup>(() => new TwitterStartup());

        public TweetFinder()
        {
            var startup = Startup.Value;
        }

        public IEnumerable<ITweet> GetTweetsForHashTag(string hashtag)
        {
            return Search.SearchTweets(hashtag);
        }

        public IEnumerable<string> GetDistinctLocationsFromTweets(IEnumerable<ITweet> tweets)
        {
            return tweets.Where(t => !String.IsNullOrEmpty(t.Creator.Location))
                .Select(tweet => tweet.Creator.Location).ToList().Distinct();
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