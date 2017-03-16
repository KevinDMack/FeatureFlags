using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Data.Interfaces
{
    public interface IEntity
    {
        Guid Key { get; set; }

        DateTime EffectiveDate { get; set; }

        DateTime? EndDate { get; set; }
    }
}
