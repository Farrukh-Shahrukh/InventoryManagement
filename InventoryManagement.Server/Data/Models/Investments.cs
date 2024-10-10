using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace investmentsManagement.Server.Data.Models
{
    public class Investments : BaseEntity
    {

        public DateTime Date { get; set; }
        public long Amount { get; set; }
        public string Description { get; set; }
        [ForeignKey("Projects")]
        public int ProjectId { get; set; }

        [ForeignKey("Investors")]
        public int InvestorId { get; set; }

        public virtual Projects Project { get; set; }
        public virtual Investors Investor { get; set; }
    }
}
