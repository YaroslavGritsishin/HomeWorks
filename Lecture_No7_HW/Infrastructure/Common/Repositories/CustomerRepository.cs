using Domain.Common.Entities;
using Domain.Common.Repositories.Abstractions;
using Infrastructure.Common.Repositories.Abstractions;

namespace Infrastructure.Common.Repositories
{
    public class CustomerRepository: Repository<CustomerEntity, int>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext context): base(context) { }
    }
}
