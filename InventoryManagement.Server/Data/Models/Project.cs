using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace investmentsManagement.Server.Data.Models
{
    public class Projects : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectType { get; set; }
        /// <summary>
        /// In Marla
        /// </summary>
        public int Size { get; set; }
        public ICollection<Expences> Expences { get; set; }
        public ICollection<Investments> Investment { get; set; }
    }
}
