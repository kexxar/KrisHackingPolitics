namespace KMMOpenNewsBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsPost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        NewsType = c.String(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserComment",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Text = c.String(nullable: false),
                        NewsPostId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsPost", t => t.NewsPostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.NewsPostId)
                .Index(t => t.UserId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserComment", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserComment", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserComment", "NewsPostId", "dbo.NewsPost");
            DropForeignKey("dbo.NewsPost", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserComment", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserComment", new[] { "UserId" });
            DropIndex("dbo.UserComment", new[] { "NewsPostId" });
            DropIndex("dbo.NewsPost", new[] { "UserId" });
            DropTable("dbo.UserComment");
            DropTable("dbo.NewsPost");
        }
    }
}
