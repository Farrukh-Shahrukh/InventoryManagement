using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public interface IPurchaseService
    {
        List<PurchaseDTO> GetAllPurchases();
        PurchaseDTO GetPurchaseById(int id);
        PurchaseDTO CreatePurchase(PurchaseDTO purchaseDto);
    }
}
