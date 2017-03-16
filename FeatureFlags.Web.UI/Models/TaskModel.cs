using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeatureFlags.Web.UI.Models
{
    public class TaskModel
    {

    }

    public class Taskv1Model : TaskModel
    {
        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class Taskv2Model : Taskv1Model
    {
        public string AssignedTo { get; set; }
    }
}