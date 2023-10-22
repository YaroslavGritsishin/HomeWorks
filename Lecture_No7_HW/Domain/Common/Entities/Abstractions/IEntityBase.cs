namespace Domain.Common.Entities.Abstractions
{
    public interface IEntityBase<TKey> where TKey : struct
    {
        TKey Id { get; set; }
    }
}
