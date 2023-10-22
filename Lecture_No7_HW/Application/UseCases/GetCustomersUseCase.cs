using Application.DataTransferObject.Mappers;
using Application.DataTransferObject.ViewModels;
using Application.Errors;
using Application.UseCases.Contracts;
using Domain.Common.Repositories.Abstractions;

namespace Application.UseCases
{
    public class GetCustomersUseCase : IGetCustomersUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomersUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<IEnumerable<CustomerViewModel>> EcxecuteAsync()
        {
            var customers = await customerRepository.GetAllAsync();
            if (customers == null || !customers.Any())
                throw new CustomerNotFoundExeption("У Вас пока нет ни одного зарегистрированого пользователя!");
            return customers.ToViewModel();
        }
    }
}
