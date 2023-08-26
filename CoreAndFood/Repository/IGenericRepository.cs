using System.Linq.Expressions;

namespace CoreAndFood.Repository
{
    public interface IGenericRepository<T> where T : class, new()
    {
        void Add(T t);
        void Delete(T t);
        List<T> Get();
        List<T> Get(Expression<Func<T, bool>> filter);
        T Get(int id);
        List<T> Get(string p);
        void Update(T t);
    }
}