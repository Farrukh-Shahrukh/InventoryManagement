using AutoMapper;
using investmentsManagement.Server.Data;
using investmentsManagement.Server.Data.Models;
using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ExpenseService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ExpencesDTO> GetAllExpense()
        {
            var expenses = _context.Expences.Where(W => !W.IsDeleted).ToList();
            return _mapper.Map<List<ExpencesDTO>>(expenses);
        }
        public ExpencesDTO GetExpenseById(int id)
        {
            var expense = _context.Expences.Find(id);
            if (expense == null)
            {
                return null;
            }
            return _mapper.Map<ExpencesDTO>(expense);
        }
        public ExpencesDTO CreateExpense(ExpencesDTO expenseDto)
        {
            var expense = _mapper.Map<Expences>(expenseDto);
            expense.CreatedDate = DateTime.Now;
            expense.publicId = Guid.NewGuid();

            _context.Expences.Add(expense);
            _context.SaveChanges();
            return _mapper.Map<ExpencesDTO>(expense);
        }

        public ExpencesDTO UpdateExpense(int id, ExpencesDTO expenseDto)
        {
            var expense = _context.Expences.FirstOrDefault(p => p.Id == id);
            if (expense == null)
            {
                throw new Exception("Expense not found");
            }

            _mapper.Map(expenseDto, expense);
            expense.UpdatedDate = DateTime.Now;

            _context.SaveChanges();
            return _mapper.Map<ExpencesDTO>(expense);
        }

        public void DeleteExpense(int id)
        {
            var expense = _context.Expences.FirstOrDefault(p => p.Id == id);
            if (expense == null)
            {
                throw new Exception("Expense not found");
            }
            expense.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
