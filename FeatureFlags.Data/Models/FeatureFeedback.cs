using FeatureFlags.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Data.Models
{
    public class FeatureFeedback : BaseModel, IEntity
    {
        public FeatureFlag Flag { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        public string Notes { get; set; }
    }
}
