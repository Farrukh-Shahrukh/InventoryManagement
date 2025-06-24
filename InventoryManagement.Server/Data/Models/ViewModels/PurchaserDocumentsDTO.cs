using System.ComponentModel.DataAnnotations.Schema;

namespace investmentsManagement.Server.Data.Models.ViewModels
{
    public class PurchaserDocumentsDTO : BaseDTO
    {
        [ForeignKey("Purchaser")]
        public int PurchaserId { get; set; }
        [ForeignKey("Attachmments")]
        public int? AttachmentId { get; set; }
        public virtual PurchaserDTO Purchaser { get; set; }
        public virtual AttachmmentsDTO Attachmment { get; set; }
    }
}
