using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using NancyDemo.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Data.MongoDB
{
    public abstract class MongoRepository<TObject> where TObject : MongoEntity
    {
        private MongoCollection collection;

        public MongoRepository(string collectionName)
        {
            var client = new MongoClient("mongodb://monotest:monotest@localhost/test");
            var server = client.GetServer();
            var database = server.GetDatabase("test");
            collection = database.GetCollection<TObject>(collectionName);
        }

        public IQueryable<TObject> All()
        {
            return collection.AsQueryable<TObject>();
        }

        public IQueryable<TObject> Filter(System.Linq.Expressions.Expression<Func<TObject, bool>> predicate)
        {
            return collection.AsQueryable<TObject>().Where(predicate);
        }

        public IQueryable<TObject> Filter<Key>(System.Linq.Expressions.Expression<Func<TObject, bool>> filter, out int total, int index = 0, int size = 50)
        {
            throw new NotImplementedException();
        }

        public bool Contains(System.Linq.Expressions.Expression<Func<TObject, bool>> predicate)
        {
            return collection.AsQueryable<TObject>().Any(predicate);
        }

        public TObject Find(params object[] keys)
        {
            throw new NotImplementedException();
        }

        public TObject Find(System.Linq.Expressions.Expression<Func<TObject, bool>> predicate)
        {
            return collection.AsQueryable<TObject>().FirstOrDefault(predicate);
        }

        public TObject Create(TObject t)
        {            
            collection.Insert(t);
            return t;
        }

        public void Delete(TObject t)
        {
            var query = Query<TObject>.EQ(e => e.Id, t.Id);
            collection.Remove(query);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<TObject, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(TObject t)
        {
            collection.Save(t);
        }

        public int Count
        {
            get { return (int)collection.Count(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
