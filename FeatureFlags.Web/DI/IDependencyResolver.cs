using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Web
{
    public interface IDependencyResolver
    {
        TDependency Resolve<TDependency>() where TDependency : class;
    }
}
