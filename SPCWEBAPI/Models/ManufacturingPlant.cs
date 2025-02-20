using System.ComponentModel.DataAnnotations;

namespace SPCWebAPI.Models
{
    public class ManufacturingPlant
    {
        [Key]
        public int PlantID { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public int StockQuantity { get; set; }
    }
}
