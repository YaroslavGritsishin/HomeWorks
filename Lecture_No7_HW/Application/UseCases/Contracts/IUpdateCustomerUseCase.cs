using Application.DataTransferObject.ViewModels;

namespace Application.UseCases.Contracts
{
    public interface IUpdateCustomerUseCase
    {
        Task EcxecuteAsync(CustomerViewModel customer);
    }
}
