using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace InventoryManagement.Server.Data.Models.ViewModels
{
    public class LadgerDTO : BaseDTO
    {
        public BigInteger Amount { get; set; }
        public DateTime Date { get; set; }
        public string Descriptions { get; set; }

        public int InvestorId { get; set; }

        public InvestorsDTO Investor { get; set; }
    }
}
