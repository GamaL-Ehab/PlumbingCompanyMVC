using CoreLayer.BaseEntity;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories.Abstract
{
    public interface IGenericRepository<Entity> where Entity : class, IBaseEntity, new()
    {
        Task AddAsync(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
        IQueryable<Entity> GetAllAsync();
        IQueryable<Entity> Where(Expression<Func<Entity, bool>> predicate);
        Task<Entity> GetByIdAsync(int id);
    }
}
