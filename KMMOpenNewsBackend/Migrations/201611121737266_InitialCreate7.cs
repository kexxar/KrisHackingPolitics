namespace KMMOpenNewsBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserScore",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Score = c.Byte(nullable: false),
                        NewsPost_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.NewsPost", t => t.NewsPost_Id)
                .Index(t => t.UserId)
                .Index(t => t.NewsPost_Id);
            
            DropColumn("dbo.NewsPost", "Scores");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsPost", "Scores", c => c.String(nullable: false));
            DropForeignKey("dbo.UserScore", "NewsPost_Id", "dbo.NewsPost");
            DropForeignKey("dbo.UserScore", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserScore", new[] { "NewsPost_Id" });
            DropIndex("dbo.UserScore", new[] { "UserId" });
            DropTable("dbo.UserScore");
        }
    }
}
