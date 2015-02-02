using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Aptitud.SwetuggMob.Web.Views;

namespace Aptitud.SwetuggMob.Web
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {

            var model = new HomeViewModel
            {
                Tweets = new HomeViewModel.TweetItem[]
                {
                  new HomeViewModel.TweetItem{
                      Message = "Hello"
                  },
                  new HomeViewModel.TweetItem{
                      Message = "Swetugg"
                    }
                }
            };


            Get["/"] = parameters => View["Home", model];
        }
    }
}