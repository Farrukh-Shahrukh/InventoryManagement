using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace investmentsManagement.Server.Data.Models
{
    public class Expences : BaseEntity
    {
        public DateTime Date { get; set; }
        public long Amount { get; set; }
        public string Description { get; set; }
        [ForeignKey("Projects")]
        public int ProjectId { get; set; }

        [ForeignKey("ExpenceTypes")]
        public int ExpenceTypeId { get; set; }

        public virtual Projects Project { get; set; }
        public virtual ExpenceTypes ExpenceTypes { get; set; }
    }
}
