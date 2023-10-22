namespace Application.UseCases.Contracts
{
    public interface IRemoveCustomerUseCase
    {
        Task EcxecuteAsync(int id);
    }
}
