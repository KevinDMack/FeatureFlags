using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Business
{
    public class Constants
    {
        public class FlagStates
        {
            public const string Off = "Off";
            public const string Preview = "Preview";
            public const string On = "On";
        }

        public class CacheKeys
        {
            public const string FlagConfig = "FlagConfig";
        }

        public class FeatureFlags
        {
            public const string TaskScreen = "Task.Screen";
            public const string TaskProvider = "Task.Provider";
        }
    }
}
