namespace KMMOpenNewsBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserScore");
            AlterColumn("dbo.UserScore", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserScore", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserScore");
            AlterColumn("dbo.UserScore", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserScore", "Id");
        }
    }
}
