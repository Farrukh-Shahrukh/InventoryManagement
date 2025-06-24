using System.ComponentModel.DataAnnotations.Schema;

namespace investmentsManagement.Server.Data.Models
{
    public class PurchaserDocuments : BaseEntity
    {
        [ForeignKey("Purchaser")]
        public int PurchaserId { get; set; }
        [ForeignKey("Attachmments")]
        public int AttachmentId { get; set; }
        public virtual Purchaser Purchaser { get; set; }
        public virtual Attachmments Attachmment { get; set; }
    }
}
