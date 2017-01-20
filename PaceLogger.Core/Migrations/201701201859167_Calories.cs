namespace PaceLogger.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Laps", "Calories", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Laps", "Calories");
        }
    }
}
