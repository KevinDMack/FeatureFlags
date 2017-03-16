using System;

namespace FeatureFlags.Business.Providers
{
    public interface IFeatureFlagProvider
    {
        Tuple<bool, string> Enabled(string flag, string userName);
    }
}