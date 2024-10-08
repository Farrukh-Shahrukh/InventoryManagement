using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Server.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
