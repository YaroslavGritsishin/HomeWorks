using Application.DataTransferObject.Mappers;
using Application.DataTransferObject.ViewModels;
using Application.Errors;
using Application.UseCases.Contracts;
using Domain.Common.Repositories.Abstractions;

namespace Application.UseCases
{
    public class UpdateCustomerUseCase : IUpdateCustomerUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public UpdateCustomerUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task EcxecuteAsync(CustomerViewModel customer)
        {
            var foundCustomer = await customerRepository.GetAsync(customer.Id);
            if (foundCustomer != null)
                throw new CustomerNotFoundExeption($"Пользователь с идентификатором №{customer.Id} не найден");
            await customerRepository.UpdateAsync(customer.ToEntity());
        }
    }
}
