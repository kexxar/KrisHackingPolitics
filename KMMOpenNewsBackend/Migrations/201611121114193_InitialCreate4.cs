namespace KMMOpenNewsBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsPost", "Scores", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsPost", "Scores");
        }
    }
}
