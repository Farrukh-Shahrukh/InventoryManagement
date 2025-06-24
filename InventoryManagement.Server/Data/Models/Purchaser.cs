namespace investmentsManagement.Server.Data.Models
{
    public class Purchaser : BaseEntity
    {
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<PurchaserDocuments> Documents { get; set; }
        public virtual SalePurchase Property { get; set; }
    }
}
