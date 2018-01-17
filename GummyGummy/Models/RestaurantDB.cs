namespace GummyGummy.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RestaurantDB : DbContext,IYummyTummy
    {
        // Your context has been configured to use a 'RestaurantDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GummyGummy.Models.RestaurantDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RestaurantDB' 
        // connection string in the application configuration file.
        public RestaurantDB()
            : base("name=RestaurantDB")
        {
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////



        //void IYummyTummy.Add<T>(T Entity)
        //{
        //    Set<T>().Add(Entity);
        //}

        //IQueryable<T> IYummyTummy.Query<T>()
        //{
        //    return Set<T>();
        //}


        //void IYummyTummy.Remove<T>(T entity)
        //{
        //    Set<T>().Remove(entity);
        //}

        //void IYummyTummy.SaveChanges()
        //{
        //    SaveChanges();
        //}

        //void IYummyTummy.Update<T>(T entity)
        //{
        //    Entry(entity).State = EntityState.Modified;
        //}
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }

        public void Add<T>(T Entity) where T : class
        {
            Set<T>().Add(Entity);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }

        public void Remove<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        void IYummyTummy.SaveChanges()
        {
            SaveChanges();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}