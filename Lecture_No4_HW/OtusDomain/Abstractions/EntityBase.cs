using System.ComponentModel.DataAnnotations;

namespace OtusDomain.Abstractions
{
    public abstract class EntityBase : IEntityBase<int>
    {
        [Key]
        public int Id { get ; set ; }
    }
}
