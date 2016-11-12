namespace KMMOpenNewsBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewsPost", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.NewsPost", new[] { "UserId" });
            AlterColumn("dbo.NewsPost", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.NewsPost", "UserId");
            AddForeignKey("dbo.NewsPost", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsPost", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.NewsPost", new[] { "UserId" });
            AlterColumn("dbo.NewsPost", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.NewsPost", "UserId");
            AddForeignKey("dbo.NewsPost", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
