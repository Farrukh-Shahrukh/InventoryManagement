using AutoMapper;
using InventoryManagement.Server.Data;
using InventoryManagement.Server.Data.Models;
using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Models;

namespace InventoryManagement.Server.Services
{
    public class InvestorService : IInvestorsService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public InvestorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        public List<InvestorsDTO> GetAllInvestors()
        {
            var Investorss = _context.Investors.Where(W=> !W.IsDeleted).ToList();
            return _mapper.Map<List<InvestorsDTO>>(Investorss);
        }
        public InvestorsDTO GetInvestorsById(int id)
        {
            var Investors = _context.Investors.Find(id);
            if (Investors == null)
            {
                return null;
            }
            return _mapper.Map<InvestorsDTO>(Investors);
        }
        public InvestorsDTO CreateInvestors(InvestorsDTO InvestorsDto)
        {
            var Investors = _mapper.Map<Investors>(InvestorsDto);
            _context.Investors.Add(Investors);
            _context.SaveChanges();
            return _mapper.Map<InvestorsDTO>(Investors);
        }

        public InvestorsDTO UpdateInvestors(int id, InvestorsDTO InvestorsDto)
        {
            var Investors = _context.Investors.FirstOrDefault(p => p.Id == id);
            if (Investors == null)
            {
                throw new Exception("Investors not found");
            }

            _mapper.Map(InvestorsDto, Investors);
            _context.SaveChanges();
            return _mapper.Map<InvestorsDTO>(Investors);
        }

        public void DeleteInvestors(int id)
        {
            var Investors = _context.Investors.FirstOrDefault(p => p.Id == id);
            if (Investors == null)
            {
                throw new Exception("Investors not found");
            }
            Investors.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
