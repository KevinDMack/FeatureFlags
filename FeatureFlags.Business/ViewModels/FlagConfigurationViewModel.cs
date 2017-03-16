using FeatureFlags.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Business.ViewModels
{
    public class FlagConfigurationViewModel
    {
        public Guid FlagKey { get; set; }
        public string FlagKeyValue { get; set; }
        public string UserName { get; set; }
        public string StateCode { get; set; }
        public string StateDisplay { get; set; }

        public FlagConfigurationViewModel()
        {

        }

        public FlagConfigurationViewModel(FeatureStateRole featureStateRole)
        {
            this.Hydrate(featureStateRole);
        }

        public void Hydrate(FeatureStateRole model)
        {
            this.FlagKey = model.Flag.Key;
            this.FlagKeyValue = model.Flag.FlagKeyValue;
            this.UserName = model.RoleUser.UserName;
            this.StateCode = model.State.StateCode;
            this.StateDisplay = model.State.StateDisplay;
        }
    }
}
