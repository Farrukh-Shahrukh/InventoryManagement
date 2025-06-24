using System.ComponentModel.DataAnnotations.Schema;

namespace investmentsManagement.Server.Data.Models.ViewModels
{
    public class SalePurchaseAttachmentDTO : BaseDTO
    {
        [ForeignKey("SalePurchase")]
        public int SalePurchaseId { get; set; }
        [ForeignKey("Attachmments")]
        public int AttachmentId { get; set; }
        public virtual SalePurchaseDTO SalePurchase { get; set; }
        public virtual AttachmmentsDTO Attachmment { get; set; }
    }
}
