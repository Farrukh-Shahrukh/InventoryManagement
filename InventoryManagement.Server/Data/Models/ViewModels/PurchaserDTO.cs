namespace investmentsManagement.Server.Data.Models.ViewModels
{
    public class PurchaserDTO :BaseDTO
    {
        public string? Name { get; set; }
        public string? CNIC { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public ICollection<PurchaserDocumentsDTO> Documents { get; set; }

        public SalePurchaseDTO Properties { get; set; }
    }
}
