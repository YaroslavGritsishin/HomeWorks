namespace OtusDomain.Abstractions
{
    public interface IEntityBase<T> where T : struct
    {
        public T Id { get; set; }
    }
}
