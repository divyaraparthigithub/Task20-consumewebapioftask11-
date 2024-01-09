using Microsoft.EntityFrameworkCore;
using Task20_consumewebapioftask11_.Interfaces;
using Task20_consumewebapioftask11_.Models;

namespace Task20_consumewebapioftask11_.Repositories
{
    public abstract class GenericRepository<T> :IGenericRepository<T> where T : class
    {
        protected readonly ProductDbContext _context;
        protected GenericRepository(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllProducts()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllGenders()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }


    }
}
