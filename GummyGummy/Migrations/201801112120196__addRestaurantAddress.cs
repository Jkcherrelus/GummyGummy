namespace GummyGummy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _addRestaurantAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Address_Name", c => c.String());
            AddColumn("dbo.Restaurants", "Address_Street", c => c.String(nullable: false));
            AddColumn("dbo.Restaurants", "Address_Country", c => c.String());
            AddColumn("dbo.Restaurants", "Address_ZipCode", c => c.String());
            AddColumn("dbo.Restaurants", "Address_Phone", c => c.String());
            AddColumn("dbo.Restaurants", "Address_Email", c => c.String());
            AlterColumn("dbo.Restaurants", "Address_City", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Address_State", c => c.String(nullable: false));
            DropColumn("dbo.Restaurants", "Street");
            DropColumn("dbo.Restaurants", "City");
            DropColumn("dbo.Restaurants", "State");
            DropColumn("dbo.Restaurants", "Country");
            DropColumn("dbo.Restaurants", "ZipCode");
            DropColumn("dbo.Restaurants", "Phone");
            DropColumn("dbo.Restaurants", "Email");
            DropColumn("dbo.Restaurants", "Address_PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Address_PhoneNumber", c => c.String());
            AddColumn("dbo.Restaurants", "Email", c => c.String());
            AddColumn("dbo.Restaurants", "Phone", c => c.String());
            AddColumn("dbo.Restaurants", "ZipCode", c => c.String());
            AddColumn("dbo.Restaurants", "Country", c => c.String());
            AddColumn("dbo.Restaurants", "State", c => c.String());
            AddColumn("dbo.Restaurants", "City", c => c.String());
            AddColumn("dbo.Restaurants", "Street", c => c.String());
            AlterColumn("dbo.Restaurants", "Address_State", c => c.String());
            AlterColumn("dbo.Restaurants", "Address_City", c => c.String());
            DropColumn("dbo.Restaurants", "Address_Email");
            DropColumn("dbo.Restaurants", "Address_Phone");
            DropColumn("dbo.Restaurants", "Address_ZipCode");
            DropColumn("dbo.Restaurants", "Address_Country");
            DropColumn("dbo.Restaurants", "Address_Street");
            DropColumn("dbo.Restaurants", "Address_Name");
        }
    }
}
