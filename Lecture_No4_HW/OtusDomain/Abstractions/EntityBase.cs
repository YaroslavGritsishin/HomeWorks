namespace OtusDomain.Abstractions
{
    public abstract class EntityBase : IEntityBase<int>
    {
        public int Id { get ; set ; }
    }
}
