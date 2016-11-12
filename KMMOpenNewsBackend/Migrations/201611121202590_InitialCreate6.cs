namespace KMMOpenNewsBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewsPost", "NewsDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.UserComment", "CommentDate", c => c.DateTime(nullable: false, precision: 0, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserComment", "CommentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.NewsPost", "NewsDate", c => c.DateTime(nullable: false));
        }
    }
}
