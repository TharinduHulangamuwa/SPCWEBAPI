using System.ComponentModel.DataAnnotations;

namespace SPCWebAPI.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Contact { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public bool RegistrationStatus { get; set; } = false; // Default to Pending
    }
}
