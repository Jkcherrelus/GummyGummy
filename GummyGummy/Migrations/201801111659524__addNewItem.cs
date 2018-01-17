namespace GummyGummy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _addNewItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        ZipCode = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address_City = c.String(),
                        Address_PhoneNumber = c.String(),
                        Address_State = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                        DateRated = c.DateTime(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantReviews", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.RestaurantReviews", new[] { "RestaurantId" });
            DropTable("dbo.RestaurantReviews");
            DropTable("dbo.Restaurants");
        }
    }
}
