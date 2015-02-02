using System;
using System.Collections.Generic;
using Tweetinvi;

namespace Aptitud.SwetuggMob.Web.Services
{
    public class TweetFinder
    {
        public Lazy<TwitterStartup> Startup = new Lazy<TwitterStartup>(() => new TwitterStartup());

        public TweetFinder()
        {
            var startup = Startup.Value;
        }


        public IEnumerable<object> GetTweetsForHashTag(string hashtag)
        {
            return Search.SearchTweets(hashtag);
        }
    }


    public class TwitterStartup
    {
        public TwitterStartup()
        {
            TwitterCredentials.SetCredentials("619483140-7W7gRCf9S7a9fxJzPgpZUPPxKewvfPWjDIwoRjGZ", "Zzg8BB6C87SjHJEbKPPQaXFlG3fjfQqHgp59XjbPIzRco", "Av4MT6llbEPWJbsrcdJmYLlSA", "B5PpDxGpm8KSeU6W0mBX5EHKOcVsldzdo1MN0ELJbnlCqi1h5O");
        }
    }
}