using System.ComponentModel.DataAnnotations.Schema;

namespace investmentsManagement.Server.Data.Models
{
    public class SalePurchaseAttachment : BaseEntity
    {
        [ForeignKey("SalePurchase")]
        public int SalePurchaseId { get; set; }
        [ForeignKey("Attachmments")]
        public int AttachmentId { get; set; }
        public virtual SalePurchase SalePurchase { get; set; }
        public virtual Attachmments Attachmment { get; set; }
    }
}
