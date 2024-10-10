using AutoMapper;
using investmentsManagement.Server.Data;
using investmentsManagement.Server.Data.Models;
using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public class LadgerService : ILadgerService
    {


        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public LadgerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<LadgerDTO> GetAllLadger()
        {
            var Ladger = _context.Ladger.Where(W => !W.IsDeleted).ToList();
            return _mapper.Map<List<LadgerDTO>>(Ladger);
        }
        public LadgerDTO GetLadgerById(int id)
        {
            var Ladger = _context.Ladger.Find(id);
            if (Ladger == null)
            {
                return null;
            }
            return _mapper.Map<LadgerDTO>(Ladger);
        }
        public LadgerDTO CreateLadger(LadgerDTO LadgerDto)
        {
            var Project = _mapper.Map<Ladger>(LadgerDto);
            _context.Ladger.Add(Project);
            _context.SaveChanges();
            return _mapper.Map<LadgerDTO>(Project);
        }

        public LadgerDTO UpdateLadger(int id, LadgerDTO LadgerDto)
        {
            var Ladger = _context.Ladger.FirstOrDefault(p => p.Id == id);
            if (Ladger == null)
            {
                throw new Exception("Ladger not found");
            }

            _mapper.Map(LadgerDto, Ladger);
            _context.SaveChanges();
            return _mapper.Map<LadgerDTO>(Ladger);
        }

        public void DeleteLadger(int id)
        {
            var Ladger = _context.Ladger.FirstOrDefault(p => p.Id == id);
            if (Ladger == null)
            {
                throw new Exception("Ladger not found");
            }
            Ladger.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
