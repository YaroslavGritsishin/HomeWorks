using Application.DataTransferObject.Mappers;
using Application.DataTransferObject.ViewModels;
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
            await customerRepository.UpdateAsync(customer.ToEntity());
        }
    }
}
