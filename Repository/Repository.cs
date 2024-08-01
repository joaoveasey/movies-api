using movies_api.Interfaces;
using Microsoft.EntityFrameworkCore;
using movies_api.Infra;

namespace movies_api.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList(); //AsNoTracking - optimize the memory and performance 
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            //_context.SaveChanges(); (commented because Repository/UnitOfWork already does SaveChanges in the Commit method.)
            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            //_context.SaveChanges(); (commented because Repository/UnitOfWork already does SaveChanges in the Commit method.)
            return entity;
        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            //_context.SaveChanges(); (commented because Repository/UnitOfWork already does SaveChanges in the Commit method.)
            return entity;
        }
    }
}
