using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity>  where TEntity : class, new()
    {
        protected IDataContext Context;
        private bool shareContext = false;

        public Repository()
        {
            Context = new DataContext();
        }

        public Repository(IDataContext context)
        {
            Context = context;
            shareContext = true;
        }

        protected IDbSet<TEntity> Entities
        {
            get { return this.Context.Set<TEntity>(); }
        }
                
        public void Dispose()
        {
            if (shareContext && (Context != null))
                Context.Dispose();
        }

        public virtual IQueryable<TEntity> All()
        {
            return Entities.AsQueryable();
        }

        public virtual IQueryable<TEntity>
        Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate).AsQueryable<TEntity>();
        }

        public virtual IQueryable<TEntity> Filter<Key>(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? Entities.Where(filter).AsQueryable() : Entities.AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Any(predicate);
        }

        public virtual TEntity Find(params object[] keys)
        {
            return Entities.Find(keys);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.FirstOrDefault(predicate);
        }

        public virtual TEntity Create(TEntity entity)
        {
            var newEntry = Entities.Add(entity);
            if (!shareContext)
                Context.SaveChanges();
            return newEntry;
        }

        public virtual int Count
        {
            get
            {
                return Entities.Count();
            }
        }

        public virtual void Delete(TEntity entity)
        {
            Entities.Remove(entity);
            if (!shareContext)
                Context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            Entities.Attach(entity);
            entry.State = EntityState.Modified;
            if (!shareContext)
                Context.SaveChanges();
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                Entities.Remove(obj);
            if (!shareContext)
                Context.SaveChanges();
        }
    }
}
