using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
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
