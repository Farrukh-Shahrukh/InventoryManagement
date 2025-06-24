using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public interface ISalePurchaseService
    {
        public List<SalePurchaseDTO> GetAllSalePurchase();
        public SalePurchaseDTO GetSalePurchaseById(int id);
        public SalePurchaseDTO CreateSalePurchase(SalePurchaseDTO SalePurchaseDto);
        public SalePurchaseDTO UpdateSalePurchase(int id, SalePurchaseDTO SalePurchaseDto);
        public void DeleteSalePurchase(int id);
    }
}
