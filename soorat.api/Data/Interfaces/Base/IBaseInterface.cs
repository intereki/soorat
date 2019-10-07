using System.Collections.Generic;
using System.Threading.Tasks;
using soorat.api.Helpers;

namespace soorat.api.Data.Interfaces.Base
{
    public interface IBaseInterface<T> where T: class
    {
         Task<PageList<T>> GetAll(UserParams userParams);
         Task<T> Get(int id);
         void Add(T entity);
         void Update(T entity);
         void Delete(T entity);
         Task<bool> SaveAllAsync();
    }
}