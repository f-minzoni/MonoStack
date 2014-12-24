using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Data.EF
{
    public interface IDataContext : IUnitOfWork
    {        
        DbEntityEntry Entry(object entity);

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
