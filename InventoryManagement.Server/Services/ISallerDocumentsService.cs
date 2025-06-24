using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public interface ISallerDocumentsService
    {
        public List<SallerDocumentsDTO> GetAllSallerDocuments();
        public SallerDocumentsDTO GetSallerDocumentsById(int id);
        public SallerDocumentsDTO CreateSallerDocuments(SallerDocumentsDTO SallerDocumentsDto);
        public SallerDocumentsDTO UpdateSallerDocuments(int id, SallerDocumentsDTO SallerDocumentsDto);
        public void DeleteSallerDocuments(int id);
    }
}
