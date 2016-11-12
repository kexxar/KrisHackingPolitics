namespace KMMOpenNewsBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsPost", "NewsDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserComment", "CommentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserComment", "CommentDate");
            DropColumn("dbo.NewsPost", "NewsDate");
        }
    }
}
