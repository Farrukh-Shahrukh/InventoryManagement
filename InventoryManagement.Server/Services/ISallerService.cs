using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public interface ISallerService
    {
        public List<SallerDTO> GetAllSaller();
        public SallerDTO GetSallerById(int id);
        public SallerDTO CreateSaller(SallerDTO SallerDto);
        public SallerDTO UpdateSaller(int id, SallerDTO SallerDto);
        public void DeleteSaller(int id);
    }
}
