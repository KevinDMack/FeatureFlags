using FeatureFlags.Business.Interfaces;
using FeatureFlags.Business.ViewModels;
using FeatureFlags.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Business.Providers
{
    

    public class FeatureFlagDataConfigurationProvider : IFeatureFlagConfigurationProvider, IFeatureFlagDataConfigurationProvider
    {
        private IDataUnit _dataUnit;
        public FeatureFlagDataConfigurationProvider(IDataUnit dataUnit)
        {
            _dataUnit = dataUnit;
        }

        public virtual List<FlagConfigurationViewModel> GetFlagConfiguration()
        {
            return _dataUnit.FeatureStateRoleRepository.Get().Select(
                fsr => new FlagConfigurationViewModel()
                {
                    FlagKey = fsr.Flag.Key,
                    FlagKeyValue = fsr.Flag.FlagKeyValue,
                    StateCode = fsr.State.StateCode,
                    StateDisplay = fsr.State.StateDisplay,
                    UserName = fsr.RoleUser.UserName
                }).ToList();
        }
    }
}
