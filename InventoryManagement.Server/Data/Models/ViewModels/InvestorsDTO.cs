namespace InventoryManagement.Server.Data.Models.ViewModels
{
    public class InvestorsDTO : BaseDTO
    {

        public string CNIC { get; set; }
        public string Name { get; set; }
        public List<InvestmentsDTO> Investments { get; set; }
    }
}
