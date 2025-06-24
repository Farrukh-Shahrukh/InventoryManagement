using AutoMapper;
using investmentsManagement.Server.Data;
using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Data.Models;

namespace investmentsManagement.Server.Services
{
    public class SallerService : ISallerService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SallerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SallerDTO> GetAllSaller()
        {
            var Saller = _context.Saller.Where(W => !W.IsDeleted).ToList();
            return _mapper.Map<List<SallerDTO>>(Saller);
        }
        public SallerDTO GetSallerById(int id)
        {
            var Saller = _context.Saller.Find(id);
            if (Saller == null)
            {
                return null;
            }
            return _mapper.Map<SallerDTO>(Saller);
        }
        public SallerDTO CreateSaller(SallerDTO SallerDto)
        {
            var Project = _mapper.Map<Saller>(SallerDto);
            _context.Saller.Add(Project);
            _context.SaveChanges();
            return _mapper.Map<SallerDTO>(Project);
        }

        public SallerDTO UpdateSaller(int id, SallerDTO SallerDto)
        {
            var Saller = _context.Saller.FirstOrDefault(p => p.Id == id);
            if (Saller == null)
            {
                throw new Exception("Saller not found");
            }

            _mapper.Map(SallerDto, Saller);
            _context.SaveChanges();
            return _mapper.Map<SallerDTO>(Saller);
        }

        public void DeleteSaller(int id)
        {
            var Saller = _context.Saller.FirstOrDefault(p => p.Id == id);
            if (Saller == null)
            {
                throw new Exception("Saller not found");
            }
            Saller.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
