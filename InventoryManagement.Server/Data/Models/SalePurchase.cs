using System.ComponentModel.DataAnnotations.Schema;

namespace investmentsManagement.Server.Data.Models
{
    public class SalePurchase : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PropertyNumber { get; set; }
        /// <summary>
        /// House/Plot
        /// </summary>
        public int PropertyType { get; set; }
        /// <summary>
        /// In Marla
        /// </summary>
        public int Size { get; set; }
        [ForeignKey("Saller")]
        public int SallerId { get; set; }
        public virtual Saller Saller { get; set; }
        [ForeignKey("Purchaser")]
        public int PurchaserId { get; set; }
        public virtual Purchaser Purchaser { get; set; }
        public ICollection<SalePurchaseAttachment> attachments { get; set; }
    }
}
