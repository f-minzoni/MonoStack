using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Models
{
    public class Like : MongoEntity
    {
        public Dinner Dinner { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
