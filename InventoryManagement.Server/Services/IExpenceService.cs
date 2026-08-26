using InventoryManagement.Server.Data.Models.ViewModels;

namespace InventoryManagement.Server.Services
{
    public interface IExpenceService
    {
        IEnumerable<ExpencesDTO> GetAllExpences();
        ExpencesDTO GetExpenceById(int id);
        ExpencesDTO CreateExpence(ExpencesDTO expenceDto);
        ExpencesDTO UpdateExpence(int id, ExpencesDTO expenceDto);
        bool DeleteExpence(int id);
        Task<string> UploadExpensePicture(int expenceId, IFormFile file);
    }
}
