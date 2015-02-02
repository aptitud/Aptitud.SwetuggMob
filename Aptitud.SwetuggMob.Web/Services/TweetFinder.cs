using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aptitud.SwetuggMob.Web.Services
{
    public class TweetFinder
    {
        protected Lazy<StartupTwitter> Startup = new Lazy<StartupTwitter>(() =>
            {
                return new StartupTwitter();
            });

    }

    public class StartupTwitter
    {
        public StartupTwitter()
        {
             TwitterCredentials.
        }
    }
}