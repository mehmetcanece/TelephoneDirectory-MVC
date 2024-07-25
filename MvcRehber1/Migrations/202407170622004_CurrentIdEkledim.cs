namespace MvcRehber1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrentIdEkledim : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kisiler", "CurrentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kisiler", "CurrentId");
        }
    }
}
