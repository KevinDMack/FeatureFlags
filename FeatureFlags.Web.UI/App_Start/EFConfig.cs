using FeatureFlags.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace FeatureFlags.Web.UI
{
    public class EFConfig
    {
        public static void Register()
        {
            Database.SetInitializer<DataContext>(new MigrateDatabaseToLatestVersion<DataContext, FeatureFlags.Data.Migrations.Configuration>());
            var configuration = new FeatureFlags.Data.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }
    }
}