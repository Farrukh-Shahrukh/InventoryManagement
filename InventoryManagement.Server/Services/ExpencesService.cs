using AutoMapper;
using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Data.Models;
using InventoryManagement.Server.Data;

namespace InventoryManagement.Server.Services
{
    public class ExpencesService: IExpencesService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ExpencesService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ExpencesDTO> GetAllExpences()
        {
            var Expences = _context.Expences.Where(W => !W.IsDeleted).ToList();
            return _mapper.Map<List<ExpencesDTO>>(Expences);
        }
        public ExpencesDTO GetExpencesById(int id)
        {
            var Expences = _context.Expences.Find(id);
            if (Expences == null)
            {
                return null;
            }
            return _mapper.Map<ExpencesDTO>(Expences);
        }
        public ExpencesDTO CreateExpences(ExpencesDTO ExpencesDto)
        {
            var Project = _mapper.Map<Expences>(ExpencesDto);
            _context.Expences.Add(Project);
            _context.SaveChanges();
            return _mapper.Map<ExpencesDTO>(Project);
        }

        public ExpencesDTO UpdateExpences(int id, ExpencesDTO ExpencesDto)
        {
            var Expences = _context.Expences.FirstOrDefault(p => p.Id == id);
            if (Expences == null)
            {
                throw new Exception("Expences not found");
            }

            _mapper.Map(ExpencesDto, Expences);
            _context.SaveChanges();
            return _mapper.Map<ExpencesDTO>(Expences);
        }

        public void DeleteExpences(int id)
        {
            var Expences = _context.Expences.FirstOrDefault(p => p.Id == id);
            if (Expences == null)
            {
                throw new Exception("Expences not found");
            }
            Expences.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
