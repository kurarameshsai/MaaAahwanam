using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MaaAahwanam.Dal
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        List<T> GetAll();
        IQueryable<T> Get();
        IEnumerable<T> ExecuteProcedure(string query);
        IEnumerable<T> ExecuteProcedure_WithParameters(string query, params object[] parameters);
    }
}
