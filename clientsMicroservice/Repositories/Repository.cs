using ClientsMicroservice.Data;
using Microsoft.EntityFrameworkCore;

namespace ClientsMicroservice.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository() { }

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _entities.ToListAsync();
        
        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}