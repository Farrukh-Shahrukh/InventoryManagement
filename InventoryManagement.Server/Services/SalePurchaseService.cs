using AutoMapper;
using investmentsManagement.Server.Data;
using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Data.Models;

namespace investmentsManagement.Server.Services
{
    public class SalePurchaseService : ISalePurchaseService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SalePurchaseService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SalePurchaseDTO> GetAllSalePurchase()
        {
            var SalePurchase = _context.SalePurchase.Where(W => !W.IsDeleted).ToList();
            return _mapper.Map<List<SalePurchaseDTO>>(SalePurchase);
        }
        public SalePurchaseDTO GetSalePurchaseById(int id)
        {
            var SalePurchase = _context.SalePurchase.Find(id);
            if (SalePurchase == null)
            {
                return null;
            }
            return _mapper.Map<SalePurchaseDTO>(SalePurchase);
        }
        public SalePurchaseDTO CreateSalePurchase(SalePurchaseDTO SalePurchaseDto)
        {
            var Project = _mapper.Map<SalePurchase>(SalePurchaseDto);
            _context.SalePurchase.Add(Project);
            _context.SaveChanges();
            return _mapper.Map<SalePurchaseDTO>(Project);
        }

        public SalePurchaseDTO UpdateSalePurchase(int id, SalePurchaseDTO SalePurchaseDto)
        {
            var SalePurchase = _context.SalePurchase.FirstOrDefault(p => p.Id == id);
            if (SalePurchase == null)
            {
                throw new Exception("SalePurchase not found");
            }

            _mapper.Map(SalePurchaseDto, SalePurchase);
            _context.SaveChanges();
            return _mapper.Map<SalePurchaseDTO>(SalePurchase);
        }

        public void DeleteSalePurchase(int id)
        {
            var SalePurchase = _context.SalePurchase.FirstOrDefault(p => p.Id == id);
            if (SalePurchase == null)
            {
                throw new Exception("SalePurchase not found");
            }
            SalePurchase.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
