using NancyDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Data
{
    public interface IDinnerService
    {
        Dinner Get(int dinnerId);
        List<Dinner> GetAll();
        Dinner Create(Dinner dinner);
        void Update(Dinner dinner);
        void Delete(int dinnerId);
    }
}
