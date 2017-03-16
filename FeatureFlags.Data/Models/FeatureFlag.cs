using FeatureFlags.Data.Interfaces;

namespace FeatureFlags.Data.Models
{
    public class FeatureFlag : BaseModel, IEntity
    {
        public string FlagKeyValue { get; set; }
    }
}
