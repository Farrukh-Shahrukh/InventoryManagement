using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace InventoryManagement.Server.Data.Models
{
    public class Expences: BaseEntity
    {
        public DateTime Date { get; set; }
        public Int64 Amount { get; set; }
        public string Description { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [ForeignKey("ExpenceType")]
        public int ExpenceTypeId { get; set; }

        public Projects Project { get; set; }
        public ExpenceTypes ExpenceTypes { get; set; }
    }
}
