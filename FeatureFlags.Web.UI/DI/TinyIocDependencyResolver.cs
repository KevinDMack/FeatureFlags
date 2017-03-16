using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using TinyIoC;

namespace FeatureFlags.Web.UI.DI
{
    public class TinyIocDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        protected TinyIoCContainer container;

        public TinyIocDependencyResolver(TinyIoCContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public IDependencyScope BeginScope()
        {
            var child = container.GetChildContainer();
            return new TinyIocDependencyResolver(child);
        }
    }
}