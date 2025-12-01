using RepositoryLayer.Contexts;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.Repositories.Concrete;
using RepositoryLayer.UnitOfWorks.Abstract;

namespace RepositoryLayer.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlumbingDbContext _context;

        public UnitOfWork(PlumbingDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        IGenericRepository<Entity> IUnitOfWork.GetGenericRepository<Entity>()
        {
            return new GenericRepository<Entity>(_context);
        }
    }
}
