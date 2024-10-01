using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Server.Data.Models
{
    public class ExpenceTypes: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Expences> Expences { get; set; }

    }
}
