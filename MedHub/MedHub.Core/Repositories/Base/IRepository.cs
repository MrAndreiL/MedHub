namespace MedHub.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        //void SaveChanges();
    }
}
