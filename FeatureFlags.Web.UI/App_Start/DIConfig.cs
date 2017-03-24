using FeatureFlags.Web.DI;
using FeatureFlags.Web.UI.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyIoC;

namespace FeatureFlags.Web.UI
{
    public class DIConfig
    {
        public static void Register()
        {
            Bootstrap.Instance.Register();

            var container = TinyIoCContainer.Current;

            var resolver = new TinyIocDependencyResolver(container);

            DependencyResolver.SetResolver(resolver);

            DependencyService.Instance.Set(resolver);
        }
    }
}