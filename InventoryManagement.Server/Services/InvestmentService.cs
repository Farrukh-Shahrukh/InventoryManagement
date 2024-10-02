using AutoMapper;
using InventoryManagement.Server.Data;
using InventoryManagement.Server.Data.Models;
using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Models;

namespace InventoryManagement.Server.Services
{
    public class InvestmentService : IInvestmentService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public InvestmentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        public List<InvestmentsDTO> GetAllInvestments()
        {
            var Investmentss = _context.Investments.Where(W=> !W.IsDeleted).ToList();
            return _mapper.Map<List<InvestmentsDTO>>(Investmentss);
        }
        public InvestmentsDTO GetInvestmentsById(int id)
        {
            var Investments = _context.Investments.Find(id);
            if (Investments == null)
            {
                return null;
            }
            return _mapper.Map<InvestmentsDTO>(Investments);
        }
        public InvestmentsDTO CreateInvestments(InvestmentsDTO InvestmentsDto)
        {
            var investment = _mapper.Map<Investments>(InvestmentsDto);
            investment.CreatedDate = DateTime.Now;
            investment.publicId = Guid.NewGuid();

            _context.Investments.Add(investment);
            _context.SaveChanges();
            return _mapper.Map<InvestmentsDTO>(investment);
        }

        public InvestmentsDTO UpdateInvestments(int id, InvestmentsDTO InvestmentsDto)
        {
            var investment = _context.Investments.FirstOrDefault(p => p.Id == id);
            if (investment == null)
            {
                throw new Exception("Investments not found");
            }

            _mapper.Map(InvestmentsDto, investment);
            investment.UpdatedDate = DateTime.Now;

            _context.SaveChanges();
            return _mapper.Map<InvestmentsDTO>(investment);
        }

        public void DeleteInvestments(int id)
        {
            var Investments = _context.Investments.FirstOrDefault(p => p.Id == id);
            if (Investments == null)
            {
                throw new Exception("Investments not found");
            }
            Investments.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
