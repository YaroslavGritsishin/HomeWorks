using Application.Errors;
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
            var foundCustomer = await customerRepository.GetAsync(id);
            if (foundCustomer == null) 
                throw new CustomerNotFoundExeption($"Пользователь с идентификатором №{id} не найден");
            await customerRepository.DeleteAsync(id);
        }
    }
}
