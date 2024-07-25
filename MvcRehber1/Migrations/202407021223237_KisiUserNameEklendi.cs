namespace MvcRehber1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KisiUserNameEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kisiler", "UserName", c => c.String());
            AddColumn("dbo.Kisiler", "Kullanici_Id", c => c.Int());
            CreateIndex("dbo.Kisiler", "Kullanici_Id");
            AddForeignKey("dbo.Kisiler", "Kullanici_Id", "dbo.Kullanicis", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kisiler", "Kullanici_Id", "dbo.Kullanicis");
            DropIndex("dbo.Kisiler", new[] { "Kullanici_Id" });
            DropColumn("dbo.Kisiler", "Kullanici_Id");
            DropColumn("dbo.Kisiler", "UserName");
        }
    }
}
