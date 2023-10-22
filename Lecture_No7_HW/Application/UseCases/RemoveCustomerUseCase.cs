using Application.UseCases.Contracts;
using Domain.Common.Repositories.Abstractions;

namespace Application.UseCases
{
    public class RemoveCustomerUseCase : IRemoveCustomerUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public RemoveCustomerUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task EcxecuteAsync(int id)
        {
            await customerRepository.DeleteAsync(id);
        }
    }
}
