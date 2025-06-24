using System.ComponentModel.DataAnnotations.Schema;

namespace investmentsManagement.Server.Data.Models.ViewModels
{
    public class SalePurchaseDTO : BaseDTO
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
        public ICollection<SalePurchaseAttachmentDTO> attachments { get; set; }
    }
}
