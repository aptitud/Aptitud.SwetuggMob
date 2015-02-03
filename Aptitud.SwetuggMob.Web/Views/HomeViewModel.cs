using System.Collections.Generic;
using System.Linq;
using Tweetinvi.Core.Interfaces;

namespace Aptitud.SwetuggMob.Web.Views
{
    public class HomeViewModel
    {
        public IEnumerable<TweetItem> Tweets { get; set; }

        public class TweetItem
        {
            public string Message { get; set; }

            public string Author { get; set; }

            public string AuthorLocation { get; set; }

            public static TweetItem Create(ITweet tweet)
            {
                return new TweetItem
                {
                    Message = tweet.Text,
                    Author = tweet.Creator.Name,
                    AuthorLocation = tweet.Creator.Location
                };
            }
        }

        public static HomeViewModel Create(IEnumerable<ITweet> tweets)
        {
            return new HomeViewModel
            {
                Tweets = tweets.Select(TweetItem.Create),
            };
        }
    }
}