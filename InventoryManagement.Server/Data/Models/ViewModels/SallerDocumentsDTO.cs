using System.ComponentModel.DataAnnotations.Schema;

namespace investmentsManagement.Server.Data.Models.ViewModels
{
    public class SallerDocumentsDTO:BaseDTO
    {
        [ForeignKey("Saller")]
        public int SallerId { get; set; }
        [ForeignKey("Attachmments")]
        public int AttachmentId { get; set; }
        public virtual SallerDTO Saller { get; set; }
        public virtual AttachmmentsDTO Attachmment { get; set; }
    }
}
