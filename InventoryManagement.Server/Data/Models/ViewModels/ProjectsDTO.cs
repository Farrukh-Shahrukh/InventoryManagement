namespace InventoryManagement.Server.Data.Models.ViewModels
{
    public class ProjectsDTO:BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ExpencesDTO> Expences { get; set; }
        public List<InvestmentsDTO> Investment { get; set; }
    }
}
