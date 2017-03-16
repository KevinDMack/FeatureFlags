using FeatureFlags.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeatureFlags.Web.UI.Interfaces
{
    public interface ITaskProvider
    {
        List<Taskv2Model> GetTaskModel();
    }

    public interface ITaskv1Provider : ITaskProvider
    {

    }

    public interface ITaskv2Provider : ITaskProvider
    {

    }
}