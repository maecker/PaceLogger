namespace PaceLogger.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "DisplayName", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Users", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Username" });
            AlterColumn("dbo.Users", "DisplayName", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
        }
    }
}
