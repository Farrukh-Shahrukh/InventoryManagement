using AutoMapper;
using investmentsManagement.Server.Data;
using investmentsManagement.Server.Data.Models;
using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public class ExpenceTypeService : IExpenceTypeService
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
            var expenseType = _mapper.Map<ExpenceTypes>(ExpenceTypesDto);
            expenseType.CreatedDate = DateTime.Now;
            expenseType.publicId = Guid.NewGuid();

            _context.ExpenceTypes.Add(expenseType);
            _context.SaveChanges();
            return _mapper.Map<ExpenceTypesDTO>(expenseType);
        }

        public ExpenceTypesDTO UpdateExpenceTypes(int id, ExpenceTypesDTO ExpenceTypesDto)
        {
            var expenseType = _context.ExpenceTypes.FirstOrDefault(p => p.Id == id);
            if (expenseType == null)
            {
                throw new Exception("ExpenceTypes not found");
            }

            _mapper.Map(ExpenceTypesDto, expenseType);
            expenseType.UpdatedDate = DateTime.Now;

            _context.SaveChanges();
            return _mapper.Map<ExpenceTypesDTO>(expenseType);
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
