namespace MvcRehber1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KisiKullaniciIdEkledim : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kisiler", "Kullanici_Id", "dbo.Kullanicis");
            DropIndex("dbo.Kisiler", new[] { "Kullanici_Id" });
            AddColumn("dbo.Kisiler", "Kullanici_Id1", c => c.Int());
            AlterColumn("dbo.Kisiler", "Kullanici_Id", c => c.String());
            CreateIndex("dbo.Kisiler", "Kullanici_Id1");
            AddForeignKey("dbo.Kisiler", "Kullanici_Id1", "dbo.Kullanicis", "Id");
            DropColumn("dbo.Kisiler", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kisiler", "UserName", c => c.String());
            DropForeignKey("dbo.Kisiler", "Kullanici_Id1", "dbo.Kullanicis");
            DropIndex("dbo.Kisiler", new[] { "Kullanici_Id1" });
            AlterColumn("dbo.Kisiler", "Kullanici_Id", c => c.Int());
            DropColumn("dbo.Kisiler", "Kullanici_Id1");
            CreateIndex("dbo.Kisiler", "Kullanici_Id");
            AddForeignKey("dbo.Kisiler", "Kullanici_Id", "dbo.Kullanicis", "Id");
        }
    }
}
