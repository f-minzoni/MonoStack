using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using NancyDemo.Models;

namespace NancyDemo.Data
{    
    public class MyContext : DbContext, IMyContext
    {
        public MyContext() : base("name=MyEntities") { }

        public DbSet<Dinner> Dinners { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
