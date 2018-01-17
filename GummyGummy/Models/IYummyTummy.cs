using System.Linq;
using System;

namespace GummyGummy.Models
{
    internal interface IYummyTummy: IDisposable
    {
        void Add<T>(T Entity) where T : class;
        IQueryable<T> Query<T>() where T:class;
        void Remove<T>(T entity) where T : class;
        void SaveChanges();
        void Update<T>(T entity) where T : class;
    }
}