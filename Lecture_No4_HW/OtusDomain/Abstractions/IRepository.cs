namespace OtusDomain.Abstractions
{
    public interface IRepository<TEntity, TKey> where TKey: struct where TEntity : IEntityBase<TKey> 
    {
       
    }
}
