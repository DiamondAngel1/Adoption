using Animal.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Animal.Infrastructure.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppAnimalContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppAnimalContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();   // Це сама табличка з якомю працює даний репозиторій.
        }
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<T> GetQuery()
        {
            return _dbSet.AsQueryable();
        }
    }
}
