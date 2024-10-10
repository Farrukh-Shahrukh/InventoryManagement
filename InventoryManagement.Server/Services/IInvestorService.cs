using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public interface IInvestorService
    {
        public List<InvestorsDTO> GetAllInvestors();
        public InvestorsDTO GetInvestorsById(int id);
        public InvestorsDTO CreateInvestors(InvestorsDTO InvestorsDto);
        public InvestorsDTO UpdateInvestors(int id, InvestorsDTO InvestorsDto);
        public void DeleteInvestors(int id);
    }
}
