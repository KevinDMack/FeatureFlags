namespace FeatureFlags.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeatureFlags",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        FlagKeyValue = c.String(),
                        EffectiveDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.FeatureRoles",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        RoleName = c.String(),
                        EffectiveDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.FeatureRoleUsers",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        UserName = c.String(),
                        EffectiveDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Role_Key = c.Guid(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.FeatureRoles", t => t.Role_Key)
                .Index(t => t.Role_Key);
            
            CreateTable(
                "dbo.FeatureStates",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        StateCode = c.String(),
                        StateDisplay = c.String(),
                        EffectiveDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.FeatureStateRoles",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        EffectiveDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Flag_Key = c.Guid(),
                        RoleUser_Key = c.Guid(),
                        State_Key = c.Guid(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.FeatureFlags", t => t.Flag_Key)
                .ForeignKey("dbo.FeatureRoleUsers", t => t.RoleUser_Key)
                .ForeignKey("dbo.FeatureStates", t => t.State_Key)
                .Index(t => t.Flag_Key)
                .Index(t => t.RoleUser_Key)
                .Index(t => t.State_Key);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeatureStateRoles", "State_Key", "dbo.FeatureStates");
            DropForeignKey("dbo.FeatureStateRoles", "RoleUser_Key", "dbo.FeatureRoleUsers");
            DropForeignKey("dbo.FeatureStateRoles", "Flag_Key", "dbo.FeatureFlags");
            DropForeignKey("dbo.FeatureRoleUsers", "Role_Key", "dbo.FeatureRoles");
            DropIndex("dbo.FeatureStateRoles", new[] { "State_Key" });
            DropIndex("dbo.FeatureStateRoles", new[] { "RoleUser_Key" });
            DropIndex("dbo.FeatureStateRoles", new[] { "Flag_Key" });
            DropIndex("dbo.FeatureRoleUsers", new[] { "Role_Key" });
            DropTable("dbo.FeatureStateRoles");
            DropTable("dbo.FeatureStates");
            DropTable("dbo.FeatureRoleUsers");
            DropTable("dbo.FeatureRoles");
            DropTable("dbo.FeatureFlags");
        }
    }
}
