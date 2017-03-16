using FeatureFlags.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Data.Models
{
    public class FeatureRole : BaseModel, IEntity
    {
        public string RoleName { get; set; }
    }
}
