using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace InventoryManagement.Server.Data.Models
{
    public class Ladger: BaseEntity
    {
        public Int64 Amount { get; set; }
        public DateTime Date { get; set; }
        public string Descriptions { get; set; }
        /// <summary>
        /// 1 for Investment
        /// 2 for Profit
        /// 3 for advance/Loan
        /// </summary>
        public int LadgerType { get; set; }

        [ForeignKey("Investors")]
        public int InvestorId { get; set; }

        public Investors Investor { get; set; }
    }
}
