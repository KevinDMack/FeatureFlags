using FeatureFlags.Business.Interfaces;
using FeatureFlags.Business.Providers;
using FeatureFlags.Web.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FeatureFlags.Web.Providers
{
    public class FlagCheckProvider : IFlagCheckProvider
    {
        private static IFlagCheckProvider _instance;
        public static IFlagCheckProvider Instance
        {
            get
            {
                var resolver = DependencyService.Instance.GetDependencyInjection();
                var _instance = resolver.Resolve<IFlagCheckProvider>();
                return _instance;
            }
        }

        private IFeatureFlagProvider _flagProvider;
        public FlagCheckProvider(IFeatureFlagProvider flagProvider)
        {
            _flagProvider = flagProvider;
        }

        public bool IsEnabled(string key)
        {
            return this.IsEnabled(key, HttpContext.Current.User.Identity.Name);
        }

        public bool IsEnabled(string key, string userName)
        {
            var enabled = _flagProvider.Enabled(key, userName);
            return enabled.Item1;
        }

        public bool IsPreview(string key)
        {
            return this.IsPreview(key, HttpContext.Current.User.Identity.Name);
        }

        public bool IsPreview(string key, string userName)
        {
            var enabled = _flagProvider.Enabled(key, userName);
            if (enabled.Item1 == true)
            {
                if (!String.IsNullOrEmpty(enabled.Item2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return enabled.Item1;
            }
        }

    }
}
