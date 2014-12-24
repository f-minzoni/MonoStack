using NancyDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Domain
{
    public interface ILikeService
    {        
        List<Like> GetAll();
        List<Like> GetAllByDinner(int dinnerId);
        void Add(Like like);        
    }
}
