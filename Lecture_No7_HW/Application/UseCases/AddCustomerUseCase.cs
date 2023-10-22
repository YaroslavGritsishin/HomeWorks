using Application.DataTransferObject.Mappers;
using Application.DataTransferObject.ViewModels;
using Application.UseCases.Contracts;
using Domain.Common.Repositories.Abstractions;

namespace Application.UseCases
{
    public class AddCustomerUseCase : IAddCustomerUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public AddCustomerUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CustomerViewModel> EcxecuteAsync(CustomerViewModel customer)
        {
            var addedCustomer = await customerRepository.AddAsync(customer.ToEntity());
            return addedCustomer.ToViewModel();
        }
    }
}
