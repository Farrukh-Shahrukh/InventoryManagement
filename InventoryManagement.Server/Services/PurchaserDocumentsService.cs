using AutoMapper;
using investmentsManagement.Server.Data;
using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Data.Models;

namespace investmentsManagement.Server.Services
{
    public class PurchaserDocumentsService : IPurchaserDocumentsService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PurchaserDocumentsService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PurchaserDocumentsDTO> GetAllPurchaserDocuments()
        {
            var PurchaserDocuments = _context.PurchaserDocuments.Where(W => !W.IsDeleted).ToList();
            return _mapper.Map<List<PurchaserDocumentsDTO>>(PurchaserDocuments);
        }
        public PurchaserDocumentsDTO GetPurchaserDocumentsById(int id)
        {
            var PurchaserDocuments = _context.PurchaserDocuments.Find(id);
            if (PurchaserDocuments == null)
            {
                return null;
            }
            return _mapper.Map<PurchaserDocumentsDTO>(PurchaserDocuments);
        }
        public PurchaserDocumentsDTO CreatePurchaserDocuments(PurchaserDocumentsDTO PurchaserDocumentsDto)
        {
            var Project = _mapper.Map<PurchaserDocuments>(PurchaserDocumentsDto);
            _context.PurchaserDocuments.Add(Project);
            _context.SaveChanges();
            return _mapper.Map<PurchaserDocumentsDTO>(Project);
        }

        public PurchaserDocumentsDTO UpdatePurchaserDocuments(int id, PurchaserDocumentsDTO PurchaserDocumentsDto)
        {
            var PurchaserDocuments = _context.PurchaserDocuments.FirstOrDefault(p => p.Id == id);
            if (PurchaserDocuments == null)
            {
                throw new Exception("PurchaserDocuments not found");
            }

            _mapper.Map(PurchaserDocumentsDto, PurchaserDocuments);
            _context.SaveChanges();
            return _mapper.Map<PurchaserDocumentsDTO>(PurchaserDocuments);
        }

        public void DeletePurchaserDocuments(int id)
        {
            var PurchaserDocuments = _context.PurchaserDocuments.FirstOrDefault(p => p.Id == id);
            if (PurchaserDocuments == null)
            {
                throw new Exception("PurchaserDocuments not found");
            }
            PurchaserDocuments.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
