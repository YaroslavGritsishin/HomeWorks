
using Application.DataTransferObject.ViewModels;

namespace Application.UseCases.Contracts
{
    public interface IGetCustomerByIdUseCase
    {
        Task<CustomerViewModel> EcxecuteAsync(int id);
    }
}
