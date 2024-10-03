using InventoryManagement.Server.Data.Models.ViewModels;

namespace InventoryManagement.Server.Services
{
    public interface IExpenseService
    {
        public List<ExpencesDTO> GetAllExpense();
        public ExpencesDTO GetExpenseById(int id);
        public ExpencesDTO CreateExpense(ExpencesDTO expenseDto);
        public ExpencesDTO UpdateExpense(int id, ExpencesDTO expenseDto);
        public void DeleteExpense(int id);
    }
}
