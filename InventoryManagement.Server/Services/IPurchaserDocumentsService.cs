using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public interface IPurchaserDocumentsService
    {
        public List<PurchaserDocumentsDTO> GetAllPurchaserDocuments();
        public PurchaserDocumentsDTO GetPurchaserDocumentsById(int id);
        public PurchaserDocumentsDTO CreatePurchaserDocuments(PurchaserDocumentsDTO PurchaserDocumentsDto);
        public PurchaserDocumentsDTO UpdatePurchaserDocuments(int id, PurchaserDocumentsDTO PurchaserDocumentsDto);
        public void DeletePurchaserDocuments(int id);
    }
}
