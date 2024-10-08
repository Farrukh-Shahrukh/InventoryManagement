using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Models;

namespace InventoryManagement.Server.Services
{
    public interface IInvestmentService
    {
        public List<InvestmentsDTO> GetAllInvestments();
        public InvestmentsDTO GetInvestmentsById(int id);
        public InvestmentsDTO CreateInvestments(InvestmentsDTO InvestmentsDto);
        public InvestmentsDTO UpdateInvestments(int id, InvestmentsDTO InvestmentsDto);
        public void DeleteInvestments(int id);
    }
}
