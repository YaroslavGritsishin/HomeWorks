using Domain.Common.Entities.Abstractions;
using Domain.Common.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Common.Repositories.Abstractions
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntityBase<TKey> where TKey : struct
    {
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var addedEntity = await context.Set<TEntity>().AddAsync(entity, cancellationToken);
            if (saveChanges)
                await SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task DeleteAsync(TKey id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var foundEntity = await context.Set<TEntity>().FindAsync(id, cancellationToken);

            if (foundEntity != null)
            {
                context.Set<TEntity>().Remove(foundEntity);
                if (saveChanges)
                    await context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) =>
           await context.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);
        

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await context.Set<TEntity>().ToListAsync(cancellationToken);
        

        public async Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken = default) =>
            await context.Set<TEntity>().FindAsync(id,cancellationToken);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await context.SaveChangesAsync(cancellationToken);

        public async Task<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var foundEntity = await context.Set<TEntity>().FindAsync(entity.Id, cancellationToken);
            if(foundEntity != null)
            {
                context.Entry(foundEntity).CurrentValues.SetValues(entity);
                if (saveChanges)
                    await context.SaveChangesAsync(cancellationToken);
            }
            return foundEntity;
        }
    }
}
