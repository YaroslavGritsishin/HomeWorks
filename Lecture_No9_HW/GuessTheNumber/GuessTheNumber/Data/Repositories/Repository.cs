using GuessTheNumber.Data.Models.Abstract;
using GuessTheNumber.Data.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace GuessTheNumber.Data.Repositories
{
    public abstract class Repository<TEntity>: IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var result = await context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return result.Entity;
        }
        public async Task<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken) =>
            await context.Set<TEntity>().FindAsync(id, cancellationToken);
        public async Task<IEnumerable<TEntity?>> GetAsync(CancellationToken cancellationToken) =>
            await context.Set<TEntity>().ToListAsync(cancellationToken);
        public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            var foundEntity = await context.Set<TEntity>().FindAsync(id);
            if (foundEntity is not null)
            {
                context.Set<TEntity>().Remove(foundEntity);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
        public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var foundEntity = await context.Set<TEntity>().FindAsync(entity.Id, cancellationToken);
            if (foundEntity is not null)
            {
                context.Entry(foundEntity).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

    }
}
