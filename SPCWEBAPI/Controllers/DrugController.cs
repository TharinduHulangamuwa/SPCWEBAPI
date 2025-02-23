using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPCWEBAPI.Data;
using SPCWEBAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPCWEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugController : ControllerBase
    {
        private readonly SPCDbContext _context;

        public DrugController(SPCDbContext context)
        {
            _context = context;
        }

        // GET: api/drug
        // Allows staff and pharmacy to search for drugs.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drug>>> GetDrugs(string search = null)
        {
            var query = _context.Drugs.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(d => d.Name.Contains(search) || d.Description.Contains(search));
            }
            var drugs = await query.ToListAsync();
            return Ok(drugs);
        }

        // GET: api/drug/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Drug>> GetDrugById(int id)
        {
            var drug = await _context.Drugs.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }
            return Ok(drug);
        }

        // POST: api/drug
        // Allows staff to add new drug details.
        [HttpPost]
        public async Task<ActionResult<Drug>> AddDrug([FromBody] Drug drug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Drugs.Add(drug);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDrugById), new { id = drug.Id }, drug);
        }

        // PUT: api/drug/{id}/update-stock
        // Allows staff to update the stock manually (e.g., after receiving new shipments).
        [HttpPut("{id}/update-stock")]
        public async Task<IActionResult> UpdateDrugStock(int id, [FromBody] int newStock)
        {
            var drug = await _context.Drugs.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }

            drug.Stock = newStock;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/drug/{id}/order
        // Allows pharmacy to place an order, deducting the ordered quantity from stock.
        [HttpPost("{id}/order")]
        public async Task<IActionResult> OrderDrug(int id, [FromBody] int quantity)
        {
            var drug = await _context.Drugs.FindAsync(id);
            if (drug == null)
            {
                return NotFound("Drug not found.");
            }

            if (quantity <= 0)
            {
                return BadRequest("Order quantity must be greater than zero.");
            }

            if (drug.Stock < quantity)
            {
                return BadRequest("Insufficient stock available.");
            }

            drug.Stock -= quantity;
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Order placed successfully", RemainingStock = drug.Stock });
        }
    }
}
