using NancyDemo.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Data.Dapper
{
    public interface IReadOnlyRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        T Find(int id);

        IEnumerable<T> All();
    }
}
