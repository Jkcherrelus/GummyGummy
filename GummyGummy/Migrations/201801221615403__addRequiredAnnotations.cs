namespace GummyGummy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _addRequiredAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Email", c => c.String());
            AlterColumn("dbo.Restaurants", "Phone", c => c.String());
        }
    }
}
