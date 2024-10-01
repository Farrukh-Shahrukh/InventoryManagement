namespace InventoryManagement.Server.Data.Models.ViewModels
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public Guid publicId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
