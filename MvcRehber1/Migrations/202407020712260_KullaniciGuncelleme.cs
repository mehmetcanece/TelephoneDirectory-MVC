namespace MvcRehber1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KullaniciGuncelleme : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kullanicis", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Kullanicis", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kullanicis", "Password", c => c.String());
            AlterColumn("dbo.Kullanicis", "Username", c => c.String());
        }
    }
}
