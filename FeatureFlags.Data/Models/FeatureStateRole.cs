using FeatureFlags.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Data.Models
{
    public class FeatureStateRole : BaseModel, IEntity
    {
        public FeatureFlag Flag { get; set; }
        public FeatureRoleUser RoleUser { get; set; }
        public FeatureState State { get; set; }
    }
}
