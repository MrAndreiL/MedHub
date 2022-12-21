using System.Linq.Expressions;

namespace MedHub.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> FindFirst(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        T Update(T entity);
        T Delete(T entity);
        Task SaveChangesAsync();
    }
}
