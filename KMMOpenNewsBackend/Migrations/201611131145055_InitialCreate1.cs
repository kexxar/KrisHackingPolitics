namespace KMMOpenNewsBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserScore", "Score", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserScore", "Score", c => c.Byte(nullable: false));
        }
    }
}
