using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace InventoryManagement.Server.Data.Models.ViewModels
{
    public class ExpencesDTO: BaseDTO
    {
        public DateTime Date { get; set; }
        public BigInteger Amount { get; set; }
        public string Description { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public ProjectsDTO Project { get; set; }
        public ExpenceTypesDTO Item { get; set; }
    }
}
