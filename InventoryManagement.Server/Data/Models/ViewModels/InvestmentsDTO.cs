using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace InventoryManagement.Server.Data.Models.ViewModels
{
    public class InvestmentsDTO : BaseDTO
    {

        public DateTime Date { get; set; }
        public BigInteger Amount { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }

        public int InvestorId { get; set; }

        public ProjectsDTO Project { get; set; }
        public InvestorsDTO Investor { get; set; }
    }
}
