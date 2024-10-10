using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public interface IExpencesService
    {
        public List<ExpencesDTO> GetAllExpences();
        public ExpencesDTO GetExpencesById(int id);
        public ExpencesDTO CreateExpences(ExpencesDTO ExpencesDto);
        public ExpencesDTO UpdateExpences(int id, ExpencesDTO ExpencesDto);
        public void DeleteExpences(int id);
    }
}
