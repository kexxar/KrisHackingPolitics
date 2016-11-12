namespace KMMOpenNewsBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserScore", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserScore", "PostId");
            AddForeignKey("dbo.UserScore", "PostId", "dbo.NewsPost", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserScore", "PostId", "dbo.NewsPost");
            DropIndex("dbo.UserScore", new[] { "PostId" });
            DropColumn("dbo.UserScore", "PostId");
        }
    }
}
