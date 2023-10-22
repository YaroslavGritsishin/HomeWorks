using Application.DataTransferObject.Mappers;
using Application.DataTransferObject.ViewModels;
using Application.Errors;
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
            var foundCustomer = (await customerRepository.FindAsync(c => 
            c.Firstname == customer.Firstname && c.Lastname == customer.Lastname)).FirstOrDefault();
            if (foundCustomer != null) 
                throw new CustomerConflictException("Такой пользователь уже сеществует");
            var addedCustomer = await customerRepository.AddAsync(customer.ToEntity());
            return addedCustomer.ToViewModel();
        }
    }
}
