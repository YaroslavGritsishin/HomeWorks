using Domain.Common.Entities.Abstractions;

namespace Domain.Common.Entities
{
    public class CustomerEntity : EntityBase<int>
    {
        public string Firstname { get; init; }
        public string Lastname { get; init; }
    }
}
