using NancyDemo.Data.EF;
using NancyDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Data
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
            var dinner = Get(dinnerId);
            base.Delete(dinner);
        }
    }
}
