using Application.DataTransferObject.ViewModels;

namespace Application.UseCases.Contracts
{
    public interface IAddCustomerUseCase
    {
        Task<CustomerViewModel> EcxecuteAsync(CustomerViewModel customer);
    }
}
