using Microsoft.AspNetCore.Mvc;
using SPCWebAPI.Models;
using System.Linq;

namespace SPCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly SPCDbContext _context;

        public SupplierController(SPCDbContext context)
        {
            _context = context;
        }

        // GET: api/supplier
        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
            return Ok(_context.Suppliers.ToList());
        }

        // POST: api/supplier
        [HttpPost]
        public IActionResult RegisterSupplier([FromBody] Supplier supplier)
        {
            if (supplier == null)
                return BadRequest("Invalid data.");

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return Ok("Supplier registered successfully.");
        }
    }
}
