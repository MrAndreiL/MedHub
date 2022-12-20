using MedHub.Core.Repositories.Base;
using MedHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedHub.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MedHubContext medHubContext;

        public Repository(MedHubContext medHubContext)
        {
            this.medHubContext = medHubContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await medHubContext.Set<T>().AddAsync(entity);
            await medHubContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await medHubContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await medHubContext.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            medHubContext.Set<T>().Update(entity);
            await medHubContext.SaveChangesAsync();
            return entity;
        }
        
        public async Task<T> Delete(T entity)
        {
            medHubContext.Set<T>().Remove(entity);
            await medHubContext.SaveChangesAsync();
            return entity;
        }
    }
}
