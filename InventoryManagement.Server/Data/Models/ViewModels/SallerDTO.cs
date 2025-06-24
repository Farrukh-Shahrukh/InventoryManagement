namespace investmentsManagement.Server.Data.Models.ViewModels
{
    public class SallerDTO :BaseDTO
    {
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual Saller Saller { get; set; }
        public ICollection<SallerDocumentsDTO> Documents { get; set; }
        public ICollection<SalePurchaseDTO> Properties { get; set; }
    }
}
