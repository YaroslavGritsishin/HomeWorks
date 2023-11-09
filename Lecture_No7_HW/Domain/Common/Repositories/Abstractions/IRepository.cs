using Domain.Common.Entities.Abstractions;
using System.Linq.Expressions;

namespace Domain.Common.Repositories.Abstractions
{
    public interface IRepository<TEntity, TKey>  where TEntity : class, IEntityBase<TKey> where TKey : struct
    {
        Task<TEntity> AddAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task DeleteAsync(TKey id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
