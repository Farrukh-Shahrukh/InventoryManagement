using System.ComponentModel.DataAnnotations.Schema;

namespace investmentsManagement.Server.Data.Models.ViewModels
{
    public class AttachmmentsDTO : BaseDTO
    {

        public byte[] Bytes { get; set; }
        public string Description { get; set; }
        public string FileExtension { get; set; }
        public decimal Size { get; set; }
    }
}
