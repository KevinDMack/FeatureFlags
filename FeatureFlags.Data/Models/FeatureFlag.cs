using FeatureFlags.Data.Interfaces;
using System.Collections.Generic;

namespace FeatureFlags.Data.Models
{
    public class FeatureFlag : BaseModel, IEntity
    {
        public string FlagKeyValue { get; set; }

        public virtual List<FeatureFeedback> Feedback { get; set; }
    }
}
