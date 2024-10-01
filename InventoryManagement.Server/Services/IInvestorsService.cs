using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Models;

namespace InventoryManagement.Server.Services
{
    public interface IInvestorsService
    {
        public List<InvestorsDTO> GetAllInvestors();
        public InvestorsDTO GetInvestorsById(int id);
        public InvestorsDTO CreateInvestors(InvestorsDTO InvestorsDto);
        public InvestorsDTO UpdateInvestors(int id, InvestorsDTO InvestorsDto);
        public void DeleteInvestors(int id);
    }
}
