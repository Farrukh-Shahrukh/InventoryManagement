namespace InventoryManagement.Server.Data.Models.ViewModels
{
    public class ExpenceTypesDTO : BaseDTO
    {

        public string Name { get; set; }
        public List<ExpencesDTO> Expences { get; set; }
    }
}
