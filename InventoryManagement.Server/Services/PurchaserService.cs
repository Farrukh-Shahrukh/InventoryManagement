using AutoMapper;
using investmentsManagement.Server.Data;
using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Data.Models;

namespace investmentsManagement.Server.Services
{
    public class PurchaserService : IPurchaserService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PurchaserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PurchaserDTO> GetAllPurchaser()
        {
            var Purchaser = _context.Purchaser.Where(W => !W.IsDeleted).ToList();
            return _mapper.Map<List<PurchaserDTO>>(Purchaser);
        }
        public PurchaserDTO GetPurchaserById(int id)
        {
            var Purchaser = _context.Purchaser.Find(id);
            if (Purchaser == null)
            {
                return null;
            }
            return _mapper.Map<PurchaserDTO>(Purchaser);
        }
        public PurchaserDTO CreatePurchaser(PurchaserDTO PurchaserDto)
        {
            var Project = _mapper.Map<Purchaser>(PurchaserDto);
            _context.Purchaser.Add(Project);
            _context.SaveChanges();
            return _mapper.Map<PurchaserDTO>(Project);
        }

        public PurchaserDTO UpdatePurchaser(int id, PurchaserDTO PurchaserDto)
        {
            var Purchaser = _context.Purchaser.FirstOrDefault(p => p.Id == id);
            if (Purchaser == null)
            {
                throw new Exception("Purchaser not found");
            }

            _mapper.Map(PurchaserDto, Purchaser);
            _context.SaveChanges();
            return _mapper.Map<PurchaserDTO>(Purchaser);
        }

        public void DeletePurchaser(int id)
        {
            var Purchaser = _context.Purchaser.FirstOrDefault(p => p.Id == id);
            if (Purchaser == null)
            {
                throw new Exception("Purchaser not found");
            }
            Purchaser.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
