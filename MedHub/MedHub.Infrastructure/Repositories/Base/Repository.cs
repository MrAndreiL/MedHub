using MedHub.Core.Repositories.Base;
using MedHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            return entity;
        }

        public async Task<T> FindFirst(Expression<Func<T, bool>> predicate)
        {
            return await medHubContext.Set<T>().AsNoTracking().AsQueryable().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await medHubContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public T Update(T entity)
        {
            medHubContext.Set<T>().Update(entity);
            return entity;
        }
        
        public T Delete(T entity)
        {
            medHubContext.Set<T>().Remove(entity);
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await medHubContext.SaveChangesAsync();
        }
    }
}
