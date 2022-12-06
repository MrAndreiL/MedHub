using MedHub.Domain.Models;

namespace MedHub.Infrastructure.Repositories.Generics
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected MedHubContext context;

        public Repository(MedHubContext context)
        {
            this.context = context;
        }

        public virtual T Add(T entity)
        {
            return context.Add(entity).Entity;
        }

        public virtual T GetById(Guid id)
        {
            return context.Find<T>(id);
        }

        public virtual T Update(T entity)
        {
            return context.Update(entity).Entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
