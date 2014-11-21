using NancyDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Data
{
    public interface IMyContext : IUnitOfWork
    {
        DbSet<Dinner> Dinners { get; set; }

        DbEntityEntry Entry(object entity);
    }
}
