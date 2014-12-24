using NancyDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Data.Dapper
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class, IEntity
    {
        IQueryable<T> AsQueryable();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Remove(T entity);

        void Attach(T entity);
    }
}
