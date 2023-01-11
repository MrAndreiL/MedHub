namespace MedHub.UI.Pages.Services
{
    public interface IDataService<T>
    {
        void Create(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetDetails(Guid id);
    }
}
