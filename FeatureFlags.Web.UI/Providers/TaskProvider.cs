using FeatureFlags.Web.UI.Interfaces;
using FeatureFlags.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeatureFlags.Web.UI.Providers
{
    public class Taskv1Provider : ITaskProvider, ITaskv1Provider
    {
        public Taskv1Provider()
        {

        }

        public virtual List<Taskv2Model> GetTaskModel()
        {
            var list = new List<Taskv2Model>()
            {
                new Taskv2Model() { Title = "Test Task 1 - v1", DueDate = DateTime.Now},
                new Taskv2Model() { Title = "Test Task 2 -v1", DueDate = DateTime.Now.AddDays(1)},
                new Taskv2Model() { Title = "Test Task 3 -v1", DueDate = DateTime.Now.AddDays(2)},
                new Taskv2Model() { Title = "Test Task 4 -v1", DueDate = DateTime.Now.AddDays(3)},
                new Taskv2Model() { Title = "Test Task 5 -v1", DueDate = DateTime.Now.AddDays(4)}
            };

            return list;
        }
    }

    public class Taskv2Provider : Taskv1Provider, ITaskProvider, ITaskv2Provider
    {
        public Taskv2Provider()
        {

        }

        public override List<Taskv2Model> GetTaskModel()
        {
            var list = new List<Taskv2Model>()
            {
                new Taskv2Model() { Title = "Test Task 1 - v2", DueDate = DateTime.Now, AssignedTo = "Kevin"},
                new Taskv2Model() { Title = "Test Task 2 -v2", DueDate = DateTime.Now.AddDays(1), AssignedTo = "Kevin"},
                new Taskv2Model() { Title = "Test Task 3 -v2", DueDate = DateTime.Now.AddDays(2), AssignedTo = "Kevin"},
                new Taskv2Model() { Title = "Test Task 4 -v2", DueDate = DateTime.Now.AddDays(3), AssignedTo = "Kevin"},
                new Taskv2Model() { Title = "Test Task 5 -v2", DueDate = DateTime.Now.AddDays(4), AssignedTo = "Kevin"}
            };
            
            return list;
        }
    }
}