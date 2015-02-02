using Aptitud.SwetuggMob.Web.Services;
using Aptitud.SwetuggMob.Web.Views;
using Nancy;

namespace Aptitud.SwetuggMob.Web
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            var tweetFinder = new TweetFinder();

            var model = HomeViewModel.Create(tweetFinder.GetTweetsForHashTag("#Swetugg"));

            Get["/"] = parameters => View["Home", model];
        }
    }
}