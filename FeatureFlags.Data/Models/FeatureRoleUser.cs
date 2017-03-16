using FeatureFlags.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Data.Models
{
    public class FeatureRoleUser : BaseModel, IEntity
    {
        public FeatureRole Role { get; set; }
        public string UserName { get; set; }
    }
}
