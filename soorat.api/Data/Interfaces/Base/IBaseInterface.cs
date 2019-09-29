using System.Collections.Generic;
using System.Threading.Tasks;

namespace soorat.api.Data.Interfaces.Base
{
    public interface IBaseInterface<T> where T: class
    {
         Task<IEnumerable<T>> GetAll();
         Task<T> Get(int id);
         void Add(T entity);
         void Update(T entity);
         void Delete(T entity);
         Task<bool> SaveAllAsync();
    }
}