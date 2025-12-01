using CoreLayer.BaseEntity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Contexts;
using RepositoryLayer.Repositories.Abstract;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories.Concrete
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class, IBaseEntity, new()
    {
        private readonly PlumbingDbContext _context;
        private readonly DbSet<Entity> _dbSet;

        public GenericRepository(PlumbingDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }

        public async Task AddAsync(Entity entity) 
        {
            await _dbSet.AddAsync(entity);
        }
        public void Update(Entity entity)
        {
            _dbSet.Update(entity);
        }
        public void Delete(Entity entity)
        {
            _dbSet.Remove(entity);
        }
        public IQueryable<Entity> GetAllAsync()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }
        public IQueryable<Entity> Where(Expression<Func<Entity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        public async Task<Entity> GetEntityByIdAsync(int id) 
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
