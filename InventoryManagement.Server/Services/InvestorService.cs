using AutoMapper;
using investmentsManagement.Server.Data;
using investmentsManagement.Server.Data.Models;
using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public class InvestorService : IInvestorService
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
            var Investors = _context.Investors.Where(W => !W.IsDeleted).ToList();
            return _mapper.Map<List<InvestorsDTO>>(Investors);
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
            var Investor = _mapper.Map<Investors>(InvestorsDto);
            Investor.CreatedDate = DateTime.Now;
            Investor.publicId = Guid.NewGuid();

            _context.Investors.Add(Investor);
            _context.SaveChanges();
            return _mapper.Map<InvestorsDTO>(Investor);
        }

        public InvestorsDTO UpdateInvestors(int id, InvestorsDTO InvestorsDto)
        {
            var investor = _context.Investors.FirstOrDefault(p => p.Id == id);
            if (investor == null)
            {
                throw new Exception("Investors not found");
            }

            _mapper.Map(InvestorsDto, investor);
            investor.UpdatedDate = DateTime.Now;

            _context.SaveChanges();
            return _mapper.Map<InvestorsDTO>(investor);
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
