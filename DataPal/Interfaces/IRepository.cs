using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataPal.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(int id, T item);
        IQueryable<T> Find(Expression<Func<T, bool>> query);
    }
}
