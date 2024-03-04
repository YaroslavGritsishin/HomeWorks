using GuessTheNumber.Data.Models.Abstract;

namespace GuessTheNumber.Data.Repositories.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity?>> GetAsync(CancellationToken cancellationToken);
        Task RemoveAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
