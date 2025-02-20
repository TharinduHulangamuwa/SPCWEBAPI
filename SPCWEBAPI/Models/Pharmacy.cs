using System.ComponentModel.DataAnnotations;

namespace SPCWebAPI.Models
{
    public class Pharmacy
    {
        [Key]
        public int PharmacyID { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string SoftwareUsed { get; set; }
    }
}
