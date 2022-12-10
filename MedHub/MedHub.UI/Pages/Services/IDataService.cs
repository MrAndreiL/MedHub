namespace MedHub.UI.Pages.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetDetails(Guid id);
    }
}
