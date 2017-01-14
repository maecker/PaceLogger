namespace PaceLogger.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        DistanceMeters = c.Double(nullable: false),
                        Pace = c.Time(nullable: false, precision: 7),
                        AverageHeartRate = c.Byte(),
                        AltitudeMeters = c.Double(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Laps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        DistanceMeters = c.Double(nullable: false),
                        MaximumSpeed = c.Double(),
                        AverageHeartRate = c.Byte(),
                        MaximumHeartRate = c.Byte(),
                        ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .Index(t => t.ActivityId);
            
            CreateTable(
                "dbo.Trackpoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        AltitudeMeters = c.Double(),
                        DistanceMeters = c.Double(),
                        Heartrate = c.Byte(),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        LapId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Laps", t => t.LapId, cascadeDelete: true)
                .Index(t => t.LapId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trackpoints", "LapId", "dbo.Laps");
            DropForeignKey("dbo.Laps", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.Activities", "UserId", "dbo.Users");
            DropIndex("dbo.Trackpoints", new[] { "LapId" });
            DropIndex("dbo.Laps", new[] { "ActivityId" });
            DropIndex("dbo.Activities", new[] { "UserId" });
            DropTable("dbo.Trackpoints");
            DropTable("dbo.Laps");
            DropTable("dbo.Users");
            DropTable("dbo.Activities");
        }
    }
}
