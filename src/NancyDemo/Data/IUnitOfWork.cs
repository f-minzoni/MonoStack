using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Data
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}
