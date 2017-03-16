using FeatureFlags.Business.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TinyIoC;

namespace FeatureFlags.Web.Attributes
{
    public class FeatureFlagAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        private string FlagConfigKey { get; set; }

        private string ControllerName { get; set; }
        private string ActionName { get; set; }

        public FeatureFlagAttribute(string key)
        {
            FlagConfigKey = key;
        }

        public FeatureFlagAttribute(string key, string controllerName, string actionName)
        {
            FlagConfigKey = key;
            ControllerName = controllerName;
            ActionName = actionName;
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            var userName = HttpContext.Current.User.Identity.Name;

            var flagProvider = TinyIoCContainer.Current.Resolve<IFeatureFlagProvider>();

            var enabled = flagProvider.Enabled(FlagConfigKey, userName);

            if (enabled.Item1 == false)
            {
                if (!String.IsNullOrEmpty(this.ControllerName))
                {
                    actionContext.Result = new System.Web.Mvc.RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", this.ControllerName },
                        { "action", this.ActionName }
                    });
                }
                else
                {
                    actionContext.Result = new System.Web.Mvc.RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Flag" },
                        { "action", "Index" }
                    });
                }


            }
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
