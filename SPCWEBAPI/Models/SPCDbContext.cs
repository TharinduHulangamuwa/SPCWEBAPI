using Microsoft.EntityFrameworkCore;
using SPCWebAPI.Models;
using SPCWEBAPI.Models;

namespace SPCWEBAPI.Data
{
    public class SPCDbContext : DbContext
    {
        public SPCDbContext(DbContextOptions<SPCDbContext> options) : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ManufacturingPlant> ManufacturingPlants { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Drug> Drugs { get; set; }
    }
}
