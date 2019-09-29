using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soorat.api.Data.Interfaces.Base;

namespace soorat.api.Data.Repositories.Base
{
    public class BaseRepository<T> : IBaseInterface<T> where T : class
    {
        private readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
        }
        public void Update(T entity)
        {
            _context.Update(entity);
        }
        public async Task<T> Get(int id)
        {
            var value = await _context.Set<T>().FindAsync(id);

            return value;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            var values = await _context.Set<T>().ToListAsync();

            return values;
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}