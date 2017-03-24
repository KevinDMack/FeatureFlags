using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Web.DI
{
    public class DependencyService
    {
        private IDictionary<object, object> _services;

        internal DependencyService()
        {
            _services = new Dictionary<object, object>();
        }

        private static DependencyService _instance;
        public static DependencyService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DependencyService();
                }
                return _instance;
            }
        }

        public IDependencyResolver GetDependencyInjection()
        {
            try
            {
                return (IDependencyResolver)_services[typeof(IDependencyResolver)];
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException("No Dependency Injection Service Registered");

            }
        }

        public void Set(IDependencyResolver concreteInstance)
        {
            _services.Add(typeof(IDependencyResolver), concreteInstance);
        }
    }
}
