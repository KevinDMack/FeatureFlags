using FeatureFlags.Business;
using FeatureFlags.Business.Interfaces;
using FeatureFlags.Business.Providers;
using FeatureFlags.Business.ViewModels;
using FeatureFlags.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Web.Providers
{
    public class WebFeatureFlagDataConfigurationProvider : FeatureFlagDataConfigurationProvider, IFeatureFlagDataConfigurationProvider
    {
        private ICacheProvider _cacheProvider;


        public WebFeatureFlagDataConfigurationProvider(IDataUnit dataUnit, ICacheProvider cacheProvider) : base(dataUnit)
        {
            _cacheProvider = cacheProvider;
        }

        public override List<FlagConfigurationViewModel> GetFlagConfiguration()
        {
            var exists = _cacheProvider.KeyExists(Constants.CacheKeys.FlagConfig);
            if (exists)
            {
                var list = _cacheProvider.GetFromCache<List<FlagConfigurationViewModel>>(Constants.CacheKeys.FlagConfig);
                return list;
            }
            else
            {
                var list = base.GetFlagConfiguration();
                _cacheProvider.AddToCache(Constants.CacheKeys.FlagConfig, list);
                return list;
            }
        }
    }
}
