using System.ComponentModel.DataAnnotations;

namespace SPCWebAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public int PharmacyID { get; set; }

        public string DrugName { get; set; }

        public int Quantity { get; set; }

        public string OrderStatus { get; set; } = "Pending"; // Default status
    }
}
