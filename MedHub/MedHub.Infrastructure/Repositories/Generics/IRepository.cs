namespace MedHub.Infrastructure.Repositories.Generics
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Get(Guid id);
        T Update(T entity);
        IEnumerable<T> GetAll();
        void SaveChanges();
    }
}
