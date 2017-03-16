namespace FeatureFlags.Data.Migrations
{
    using FeatureFlags.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<FeatureFlags.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FeatureFlags.Data.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var flag = new FeatureFlag { Key = new Guid("F803A4D0-F7BF-4513-BAAC-EDDB4477BB94"), FlagKeyValue = "Task.Screen", EffectiveDate = DateTime.Now };
            var providerFlag = new FeatureFlag { Key = new Guid("3C25EE27-AE91-42BD-9CD4-6F6B579D3B2B"), FlagKeyValue = "Task.Provider", EffectiveDate = DateTime.Now };
            context.FeatureFlag.AddOrUpdate(f => f.Key,
                flag,
                providerFlag
                );

            var featureRole = new FeatureRole { Key = new Guid("1CC07636-7109-47D8-B647-C12CA1BB3BD3"), RoleName = "TaskTester", EffectiveDate = DateTime.Now };
            context.FeatureRole.AddOrUpdate(r => r.Key,
                featureRole
                );

            var featureRoleUser = new FeatureRoleUser { Key = new Guid("5A9C2523-A7E5-466F-A70D-9593D72CDC63"), UserName = "", Role = featureRole, EffectiveDate = DateTime.Now };
            context.FeatureRoleUser.AddOrUpdate(u => u.Key,
                featureRoleUser
                );

            var featureStateOff = new FeatureState { Key = new Guid("51EF79AF-3F6A-4DCC-AC42-A81DE3ECFE8B"), StateCode = "Off", StateDisplay = "Off", EffectiveDate = DateTime.Now };
            var featureStateOn = new FeatureState { Key = new Guid("0AD57AAC-1EB8-467B-B6C3-C4E3860929B5"), StateCode = "On", StateDisplay = "On", EffectiveDate = DateTime.Now };
            var featureStatePreview = new FeatureState { Key = new Guid("A09390BA-4D99-4E8A-8A89-E8487663E42F"), StateCode = "Preview", StateDisplay = "Preview", EffectiveDate = DateTime.Now };
            context.FeatureState.AddOrUpdate(s => s.Key,
                featureStateOff,
                featureStateOn,
                featureStatePreview
                );

            //var featureStateRole = new FeatureStateRole { Key = new Guid("9C9EC0A5-C8CF-490F-B658-91F8DCC5CF5F"), Flag = flag, RoleUser = featureRoleUser, State = featureStateOff, EffectiveDate = DateTime.Now };
            //context.FeatureStateRole.AddOrUpdate(fsr => fsr.Key,
            //    featureStateRole
            //    );

            var featureProviderStateRole = new FeatureStateRole { Key = new Guid("F9240688-A3C8-40FF-B6BB-BBCD2A9F2B37"), Flag = providerFlag, RoleUser = featureRoleUser, State = featureStatePreview, EffectiveDate = DateTime.Now };
            context.FeatureStateRole.AddOrUpdate(fsr => fsr.Key,
                featureProviderStateRole
                );

            context.SaveChanges();
        }
    }
}
