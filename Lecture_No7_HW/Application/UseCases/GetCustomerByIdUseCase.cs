
using Application.DataTransferObject.Mappers;
using Application.DataTransferObject.ViewModels;
using Application.Errors;
using Application.UseCases.Contracts;
using Domain.Common.Repositories.Abstractions;

namespace Application.UseCases
{
    public class GetCustomerByIdUseCase : IGetCustomerByIdUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomerByIdUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CustomerViewModel> EcxecuteAsync(int id)
        {
            var customer = await customerRepository.GetAsync(id);
            if (customer == null) 
                throw new CustomerNotFoundExeption($"Пользователь с идентификатором №{id} не найден");
            return customer.ToViewModel();
        }
    }
}
