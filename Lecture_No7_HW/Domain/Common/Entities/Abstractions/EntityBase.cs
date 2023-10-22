namespace Domain.Common.Entities.Abstractions
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
