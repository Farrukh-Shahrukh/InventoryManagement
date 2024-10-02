using InventoryManagement.Server.Data.Models.ViewModels;

namespace InventoryManagement.Server.Services
{
    public interface ILadgerService
    {
        public List<LadgerDTO> GetAllLadger();
        public LadgerDTO GetLadgerById(int id);
        public LadgerDTO CreateLadger(LadgerDTO LadgerDto);
        public LadgerDTO UpdateLadger(int id, LadgerDTO LadgerDto);
        public void DeleteLadger(int id);
    }
}
