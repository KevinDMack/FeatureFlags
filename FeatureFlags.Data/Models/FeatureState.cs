using FeatureFlags.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Data.Models
{
    public class FeatureState : BaseModel, IEntity
    {
        public string StateCode { get; set; }
        public string StateDisplay { get; set; }
    }
}
