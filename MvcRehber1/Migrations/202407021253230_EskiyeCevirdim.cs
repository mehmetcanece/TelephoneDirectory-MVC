namespace MvcRehber1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EskiyeCevirdim : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kisiler", "Username_Id", "dbo.Kullanicis");
            DropIndex("dbo.Kisiler", new[] { "Username_Id" });
            DropColumn("dbo.Kisiler", "Username_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kisiler", "Username_Id", c => c.Int());
            CreateIndex("dbo.Kisiler", "Username_Id");
            AddForeignKey("dbo.Kisiler", "Username_Id", "dbo.Kullanicis", "Id");
        }
    }
}
