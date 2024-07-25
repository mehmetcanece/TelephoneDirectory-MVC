namespace MvcRehber1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KisiKulUsernameEkledim : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Kisiler", name: "Kullanici_Id1", newName: "Username_Id");
            RenameIndex(table: "dbo.Kisiler", name: "IX_Kullanici_Id1", newName: "IX_Username_Id");
            DropColumn("dbo.Kisiler", "Kullanici_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kisiler", "Kullanici_Id", c => c.String());
            RenameIndex(table: "dbo.Kisiler", name: "IX_Username_Id", newName: "IX_Kullanici_Id1");
            RenameColumn(table: "dbo.Kisiler", name: "Username_Id", newName: "Kullanici_Id1");
        }
    }
}
