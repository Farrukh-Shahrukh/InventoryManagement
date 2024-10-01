using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Server.Data.Models
{
    public class Projects: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Expences> Expences { get; set; }
        public ICollection<Investments> Investment { get; set; }
    }
}
