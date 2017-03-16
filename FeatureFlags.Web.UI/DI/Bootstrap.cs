using FeatureFlags.Business;
using FeatureFlags.Business.Interfaces;
using FeatureFlags.Business.Providers;
using FeatureFlags.Data;
using FeatureFlags.Web.Providers;
using FeatureFlags.Web.UI.Interfaces;
using FeatureFlags.Web.UI.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TinyIoC;

namespace FeatureFlags.Web.UI.DI
{
    public class Bootstrap
    {
        private static Bootstrap _instance;
        public static Bootstrap Instance
        {
            get
            {
                _instance = new Bootstrap();
                return _instance;
            }
        }

        public void Register()
        {
            TinyIoCContainer.Current.Register<ICacheProvider, ServerCacheProvider>().AsSingleton();
            TinyIoCContainer.Current.Register<IFeatureFlagDataConfigurationProvider, FeatureFlagDataConfigurationProvider>().AsSingleton();
            TinyIoCContainer.Current.Register<IFeatureFlagConfigurationProvider, WebFeatureFlagDataConfigurationProvider>().AsSingleton();
            TinyIoCContainer.Current.Register<IFeatureFlagProvider, FeatureFlagProvider>().AsSingleton();
            TinyIoCContainer.Current.Register<IFlagCheckProvider, FlagCheckProvider>().AsSingleton();
            TinyIoCContainer.Current.Register<IDataUnit, DataUnit>().AsSingleton();
            TinyIoCContainer.Current.Register<ICacheProvider, ServerCacheProvider>().AsSingleton();

            //Mapping inside controllers
            TinyIoCContainer.Current.Register<ITaskv1Provider, Taskv1Provider>().AsSingleton();
            TinyIoCContainer.Current.Register<ITaskv2Provider, Taskv2Provider>().AsSingleton();

            //Mapping in bootstrap
            if (FlagCheckProvider.Instance.IsEnabled(Constants.FeatureFlags.TaskProvider, string.Empty))
            {
                TinyIoCContainer.Current.Register<ITaskProvider, Taskv2Provider>().AsSingleton();
            }
            else
            {
                if (FlagCheckProvider.Instance.IsPreview(Constants.FeatureFlags.TaskProvider, string.Empty))
                {
                    TinyIoCContainer.Current.Register<ITaskProvider, Taskv2Provider>().AsSingleton();
                }
                else
                {
                    TinyIoCContainer.Current.Register<ITaskProvider, Taskv1Provider>().AsSingleton();
                }
            }
        }
    }
}