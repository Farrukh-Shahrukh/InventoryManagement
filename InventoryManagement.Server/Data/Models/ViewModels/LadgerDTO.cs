namespace InventoryManagement.Server.Data.Models.ViewModels
{
    public class LadgerDTO
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Descriptions { get; set; }

        public int InvestorId { get; set; }

        public InvestorsDTO Investor { get; set; }
    }
}
