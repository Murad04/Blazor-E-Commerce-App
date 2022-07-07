namespace Blazor_E_Commerce.UseCases.AdminPortal.OrderDetailScreen.Interfaces
{
    public interface IProcessOrderUseCase
    {
        bool Execute(int orderID, string adminUserName);
    }
}