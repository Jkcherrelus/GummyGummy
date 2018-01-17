namespace GummyGummy.Migrations
{
    using Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GummyGummy.Models.RestaurantDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GummyGummy.Models.RestaurantDB";
        }

        protected override void Seed(GummyGummy.Models.RestaurantDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //RestaurantAddress ad = new RestaurantAddress() {
            //    City = "Reston",
            //    PhoneNumber="xxx-xxx-xxxx",
            //    State="VA",
            //};
            //Restaurant rest = new Restaurant() { Name="Domino's",Address=ad};
            //context.Restaurants.Add(rest);
        }
    }
}
