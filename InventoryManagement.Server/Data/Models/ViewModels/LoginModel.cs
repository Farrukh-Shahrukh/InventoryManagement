using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Server.Data.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
