namespace InventoryManagement.Server.Data.Models.ViewModels
{
    public class ExpencesDTO: BaseDTO
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int ExpenceTypeId { get; set; }
    }
}
