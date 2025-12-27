using API.Contexts;

namespace API.Repositories
{
    public class Repository
    {
        private readonly MyContext _context;
        public Repository(MyContext context) 
        {
            _context = context;
        }

        // GetAll
        public async Task<List<T>> GetAll<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }

        // GetById
        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        // CREATE
        public async Task<T> CreateAsync<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // UPDATE
        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync<T>(int id) where T : class
        {
            var entity = await GetByIdAsync<T>(id);
            if (entity == null)
                throw new Exception($"{typeof(T).Name} not found");

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
