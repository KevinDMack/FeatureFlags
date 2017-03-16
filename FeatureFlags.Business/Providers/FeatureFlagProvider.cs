using FeatureFlags.Business.Interfaces;
using FeatureFlags.Business.ViewModels;
using FeatureFlags.Data;
using FeatureFlags.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Business.Providers
{
    public class FeatureFlagProvider : IFeatureFlagProvider
    {
        private IFeatureFlagConfigurationProvider _flagConfigurationProvider;
        public FeatureFlagProvider(IFeatureFlagConfigurationProvider flagConfigurationProvider)
        {
            _flagConfigurationProvider = flagConfigurationProvider;
        }

        public virtual Tuple<bool,string> Enabled(string flag, string userName)
        {
            var list = _flagConfigurationProvider.GetFlagConfiguration();
            var flagCheck = list.Where(fsr => fsr.FlagKeyValue == flag).FirstOrDefault();

            if (flagCheck.StateCode == Constants.FlagStates.On)
            {
                return Tuple.Create<bool, string>(true, string.Empty);
            }
            else if (flagCheck.StateCode == Constants.FlagStates.Off)
            {
                return Tuple.Create<bool, string>(false, string.Empty);
            }
            else
            {
                var roleStateUser = list.Where(fsr => fsr.FlagKeyValue == flag && fsr.UserName == userName).FirstOrDefault();
                if (roleStateUser != null)
                {
                    switch (roleStateUser.StateCode)
                    {
                        case Constants.FlagStates.On:
                            return Tuple.Create<bool, string>(true, string.Empty);
                            break;
                        case Constants.FlagStates.Off:
                            return Tuple.Create<bool, string>(false, string.Empty);
                            break;
                        case Constants.FlagStates.Preview:
                            return Tuple.Create<bool, string>(true, roleStateUser.StateDisplay);
                            break;
                        default:
                            return Tuple.Create<bool, string>(false, string.Empty);
                            break;
                    }
                }
                else
                {
                    return Tuple.Create<bool, string>(false, string.Empty);
                }
            }
        }
    }

    
    
}
