using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace InventoryManagement.Server.Data.Models
{
    public class Investors: BaseEntity
    {
       
        public string  CNIC { get; set; }
        public string Name { get; set; }
        public ICollection<Investments> Investments { get; set; }
    }
}
