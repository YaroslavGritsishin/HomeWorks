using Application.DataTransferObject.ViewModels;

namespace Application.UseCases.Contracts
{
    public interface IGetCustomersUseCase
    {
        Task<IEnumerable<CustomerViewModel>> EcxecuteAsync();
    }
}
