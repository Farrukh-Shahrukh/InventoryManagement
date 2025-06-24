using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public interface IPurchaserService
    {
        public List<PurchaserDTO> GetAllPurchaser();
        public PurchaserDTO GetPurchaserById(int id);
        public PurchaserDTO CreatePurchaser(PurchaserDTO PurchaserDto);
        public PurchaserDTO UpdatePurchaser(int id, PurchaserDTO PurchaserDto);
        public void DeletePurchaser(int id);
    }
}
