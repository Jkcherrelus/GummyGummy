using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GummyGummy.Models
{
    public class FakeRestaurantDb : IYummyTummy
    {
        public Dictionary<Type, object> Sets = new Dictionary<Type, object>();
        public List<object> Added = new List<object>();
        public List<object> Updated = new List<object>();
        public List<object> Removed = new List<object>();
        public bool Saved = false;
        #region CRUD to Fake DB

        public void Add<T>(T Entity) where T : class
        {
            Added.Add(Entity);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Sets[typeof(T)] as IQueryable<T>;
        }

        public void Remove<T>(T entity) where T : class
        {
            Removed.Remove(entity);
        }

        public void SaveChanges()
        {
            Saved = true;
        }

        public void Update<T>(T entity) where T : class
        {
            Updated.Add(entity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}