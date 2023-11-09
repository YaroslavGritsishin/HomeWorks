using Domain.Common.Entities;

namespace Domain.Common.Repositories.Abstractions
{
    public interface ICustomerRepository : IRepository<CustomerEntity, int>
    {
    }
}
