using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Conventions;
using Nancy.Helpers;

namespace Aptitud.SwetuggMob.Web
{
    public class Bootstrapper : Nancy.DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Scripts", "Scripts"));
        }
    }
}