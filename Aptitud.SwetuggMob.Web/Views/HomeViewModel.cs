using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aptitud.SwetuggMob.Web.Views
{
    public class HomeViewModel
    {
        public IEnumerable<TweetItem> Tweets { get; set; }

        public class TweetItem
        {
            public string Message { get; set; }
        }
    }
}