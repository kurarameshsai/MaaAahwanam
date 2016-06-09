using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

namespace MaaAahwanam.Dal
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        DbContext _repositoryContext;
        DbSet<T> set;
        public BaseRepository(DbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            set = _repositoryContext.Set<T>();
        }


        public void Add(T entity)
        {
            set.Add(entity);
        }

        public void Update(T entity)
        {
            set.Attach(entity);
        }

        public void Delete(int id)
        {

        }

        public void Delete(T entity)
        {
            set.Remove(entity);
        }


        public IQueryable<T> Get()
        {
            return set;
        }

        List<T> IRepository<T>.GetAll()
        {
            //throw new NotImplementedException();
            return set.ToList<T>();
        }

        public IEnumerable<T> ExecuteProcedure(string query)
        {
            return _repositoryContext.Database.SqlQuery<T>(query);
        }


        public IEnumerable<T> ExecuteProcedure_WithParameters(string query, params object[] parameters)
        {
            return _repositoryContext.Database.SqlQuery<T>(query, parameters);
        }

    }
}
