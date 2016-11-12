namespace KMMOpenNewsBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserScore", "UserId", "dbo.AspNetUsers");
            AddColumn("dbo.UserScore", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserScore", "ApplicationUser_Id");
            AddForeignKey("dbo.UserScore", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserScore", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserScore", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserScore", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserScore", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.UserScore", "ApplicationUser_Id");
            AddForeignKey("dbo.UserScore", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
