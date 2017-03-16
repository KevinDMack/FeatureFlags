using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Business.Interfaces
{
    public interface IFlagCheckProvider
    {
        bool IsEnabled(string key);
        bool IsEnabled(string key, string userName);
        bool IsPreview(string key);
        bool IsPreview(string key, string userName);
    }
}
