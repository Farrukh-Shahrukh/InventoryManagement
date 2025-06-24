using AutoMapper;
using investmentsManagement.Server.Data;
using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Data.Models;

namespace investmentsManagement.Server.Services
{
    public class SallerDocumentsService : ISallerDocumentsService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SallerDocumentsService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SallerDocumentsDTO> GetAllSallerDocuments()
        {
            var SallerDocuments = _context.SallerDocuments.Where(W => !W.IsDeleted).ToList();
            return _mapper.Map<List<SallerDocumentsDTO>>(SallerDocuments);
        }
        public SallerDocumentsDTO GetSallerDocumentsById(int id)
        {
            var SallerDocuments = _context.SallerDocuments.Find(id);
            if (SallerDocuments == null)
            {
                return null;
            }
            return _mapper.Map<SallerDocumentsDTO>(SallerDocuments);
        }
        public SallerDocumentsDTO CreateSallerDocuments(SallerDocumentsDTO SallerDocumentsDto)
        {
            var Project = _mapper.Map<SallerDocuments>(SallerDocumentsDto);
            _context.SallerDocuments.Add(Project);
            _context.SaveChanges();
            return _mapper.Map<SallerDocumentsDTO>(Project);
        }

        public SallerDocumentsDTO UpdateSallerDocuments(int id, SallerDocumentsDTO SallerDocumentsDto)
        {
            var SallerDocuments = _context.SallerDocuments.FirstOrDefault(p => p.Id == id);
            if (SallerDocuments == null)
            {
                throw new Exception("SallerDocuments not found");
            }

            _mapper.Map(SallerDocumentsDto, SallerDocuments);
            _context.SaveChanges();
            return _mapper.Map<SallerDocumentsDTO>(SallerDocuments);
        }

        public void DeleteSallerDocuments(int id)
        {
            var SallerDocuments = _context.SallerDocuments.FirstOrDefault(p => p.Id == id);
            if (SallerDocuments == null)
            {
                throw new Exception("SallerDocuments not found");
            }
            SallerDocuments.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
