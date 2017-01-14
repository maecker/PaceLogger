namespace PaceLogger.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCaloriesAndSport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Sport", c => c.Int());
            AddColumn("dbo.Activities", "Calories", c => c.Short());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "Calories");
            DropColumn("dbo.Activities", "Sport");
        }
    }
}
