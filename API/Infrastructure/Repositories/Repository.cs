using API.Infrastructure.Contexts;
using API.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MyContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Get All
        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        // Get By Id
        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);  // .FirstOrDefaultAsync(x => x.Id == id);
        }

        // Insert
        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Update
        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception($"{typeof(T).Name} not found");

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
