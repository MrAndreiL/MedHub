using MedHub.Core.Repositories.Base;
using MedHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedHub.Infrastructure.Repositories.Base
{
    /* Sources:
     * - https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
     * - https://stackoverflow.com/questions/54169736/what-is-better-way-to-update-data-in-ef-core
     * - https://stackoverflow.com/questions/48086507/how-to-handle-updates-in-a-rest-api
    */
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MedHubContext context;

        public Repository(MedHubContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T?> FindByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> UpdateAsync(Guid id, T entity)
        {
            T? exist = await context.Set<T>().FindAsync(id);
            if (exist == null) 
            {
                return null;
            }

            context.Entry(exist).CurrentValues.SetValues(entity);
            
            return exist;
        }
        
        public async Task<T?> DeleteAsync(Guid id)
        {
            T? exist = await context.Set<T>().FindAsync(id);
            if (exist == null)
            {
                return null;
            }

            context.Set<T>().Remove(exist);

            return exist;
        }
    }
}
