namespace FeatureFlags.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeedbackModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeatureFeedbacks",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        UserName = c.String(maxLength: 100),
                        Notes = c.String(),
                        EffectiveDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Flag_Key = c.Guid(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.FeatureFlags", t => t.Flag_Key)
                .Index(t => t.Flag_Key);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeatureFeedbacks", "Flag_Key", "dbo.FeatureFlags");
            DropIndex("dbo.FeatureFeedbacks", new[] { "Flag_Key" });
            DropTable("dbo.FeatureFeedbacks");
        }
    }
}
