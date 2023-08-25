using CoreAndFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreAndFood.Repository
{
    public class GenericRepository<T> where T : class, new()
    {
        private CoreAndFoodContext _context;

        public GenericRepository(CoreAndFoodContext context)
        {
            _context = context;
        }
  

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public void Add(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Set<T>().Update(t);
            _context.SaveChanges();
        }

        public T Get(int id)
        {
           return _context.Set<T>().Find(id);
        }

        public List<T> Get(string p)
        {
            return _context.Set<T>().Include(p).ToList();
        }

        public List<T> Get(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }
    }
}
