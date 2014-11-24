using NancyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Data
{
    public class LikeService : MongoRepository<Like>, ILikeService 
    {
        public LikeService() : base("likes") { }

        public List<Like> GetAll()
        {
            return base.All().ToList();
        }

        public List<Like> GetAllByDinner(int dinnerId)
        {
            Expression<Func<Like, bool>> find = l => l.Dinner.Id == dinnerId;
            return base.Filter(find).ToList();
        }

        public void Add(Like like)
        {
            like.Timestamp = DateTime.Now;
            base.Create(like);
        }
    }
}
