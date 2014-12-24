using NancyDemo.Data.Dapper;
using NancyDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Data.Dapper
{
    public class DinnerService : Repository<Dinner>, IDinnerService
    {       

        public Dinner Get(int dinnerId)
        {
            return base.Find(dinnerId);
        }

        public List<Dinner> GetAll()
        {
            return base.All().ToList();
        }             

        public void Delete(int dinnerId)
        {
            throw new NotImplementedException();
        }

        public Dinner Create(Dinner dinner)
        {
            throw new NotImplementedException();
        }

        public void Update(Dinner dinner)
        {
            throw new NotImplementedException();
        }
    }
}
