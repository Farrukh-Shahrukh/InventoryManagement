using System.ComponentModel.DataAnnotations.Schema;

namespace investmentsManagement.Server.Data.Models
{
    public class SallerDocuments : BaseEntity
    {
        [ForeignKey("Saller")]
        public int SallerId { get; set; }
        [ForeignKey("Attachmments")]
        public int AttachmentId { get; set; }
        public virtual Saller Saller { get; set; }
        public virtual Attachmments Attachmment { get; set; }
    }
}
