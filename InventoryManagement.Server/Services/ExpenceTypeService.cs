using AutoMapper;
using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Data.Models;
using InventoryManagement.Server.Data;

namespace InventoryManagement.Server.Services
{
    public class ExpenceTypeService: IExpenceTypeService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ExpenceTypeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ExpenceTypesDTO> GetAllExpenceTypes()
        {
            var ExpenceTypes = _context.ExpenceTypes.Where(W => !W.IsDeleted).ToList();
            return _mapper.Map<List<ExpenceTypesDTO>>(ExpenceTypes);
        }
        public ExpenceTypesDTO GetExpenceTypesById(int id)
        {
            var ExpenceTypes = _context.ExpenceTypes.Find(id);
            if (ExpenceTypes == null)
            {
                return null;
            }
            return _mapper.Map<ExpenceTypesDTO>(ExpenceTypes);
        }
        public ExpenceTypesDTO CreateExpenceTypes(ExpenceTypesDTO ExpenceTypesDto)
        {
            var Project = _mapper.Map<ExpenceTypes>(ExpenceTypesDto);
            _context.ExpenceTypes.Add(Project);
            _context.SaveChanges();
            return _mapper.Map<ExpenceTypesDTO>(Project);
        }

        public ExpenceTypesDTO UpdateExpenceTypes(int id, ExpenceTypesDTO ExpenceTypesDto)
        {
            var ExpenceTypes = _context.ExpenceTypes.FirstOrDefault(p => p.Id == id);
            if (ExpenceTypes == null)
            {
                throw new Exception("ExpenceTypes not found");
            }

            _mapper.Map(ExpenceTypesDto, ExpenceTypes);
            _context.SaveChanges();
            return _mapper.Map<ExpenceTypesDTO>(ExpenceTypes);
        }

        public void DeleteExpenceTypes(int id)
        {
            var ExpenceTypes = _context.ExpenceTypes.FirstOrDefault(p => p.Id == id);
            if (ExpenceTypes == null)
            {
                throw new Exception("ExpenceTypes not found");
            }
            ExpenceTypes.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
