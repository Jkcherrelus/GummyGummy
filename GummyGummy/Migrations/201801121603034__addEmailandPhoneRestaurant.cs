namespace GummyGummy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _addEmailandPhoneRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Phone", c => c.String());
            AddColumn("dbo.Restaurants", "Email", c => c.String());
            DropColumn("dbo.Restaurants", "Address_Phone");
            DropColumn("dbo.Restaurants", "Address_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Address_Email", c => c.String());
            AddColumn("dbo.Restaurants", "Address_Phone", c => c.String());
            DropColumn("dbo.Restaurants", "Email");
            DropColumn("dbo.Restaurants", "Phone");
        }
    }
}
