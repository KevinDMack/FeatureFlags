using FeatureFlags.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Business.Interfaces
{
    public interface IFeatureFlagConfigurationProvider
    {
        List<FlagConfigurationViewModel> GetFlagConfiguration();
    }

    
}
