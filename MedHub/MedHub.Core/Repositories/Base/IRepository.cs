namespace MedHub.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T?> FindByIdAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T?> UpdateAsync(Guid id, T entity);
        Task<T?> DeleteAsync(Guid id);
    }
}
