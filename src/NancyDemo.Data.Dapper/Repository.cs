using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Configuration;
using NancyDemo.Domain;

namespace NancyDemo.Data.Dapper
{
    public class Repository<T> : IReadOnlyRepository<T> where T : class, IEntity
    {
        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(ConfigurationManager.ConnectionStrings["MyEntities"].ConnectionString);
            }
        }

        public T Find(int id)
        {
            T item;
                        
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                //todo: improve table mapping
                item = cn.Query<T>("SELECT * FROM " + typeof(T).Name + "s" + " WHERE ID=@ID", new { ID = id }).SingleOrDefault();
            }

            return item;
        }

        public IEnumerable<T> All()
        {
            IEnumerable<T> items = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                //todo: improve table mapping
                items = cn.Query<T>("SELECT * FROM " + typeof(T).Name + "s");
            }

            return items;
        }
    }
}