using System;
using System.Collections.Generic;
using System.Configuration;
using Tweetinvi;
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