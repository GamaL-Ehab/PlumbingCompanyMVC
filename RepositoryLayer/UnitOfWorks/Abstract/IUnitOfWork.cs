using CoreLayer.BaseEntity;
using RepositoryLayer.Repositories.Abstract;

namespace RepositoryLayer.UnitOfWorks.Abstract
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        IGenericRepository<Entity> GetGenericRepository<Entity>() where Entity : class, IBaseEntity, new();
        ValueTask DisposeAsync();
    }
}
