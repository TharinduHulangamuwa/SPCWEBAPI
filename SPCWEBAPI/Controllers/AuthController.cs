using Microsoft.AspNetCore.Mvc;
using SPCWEBAPI.Models;

namespace SPCWEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // POST: api/Auth/staff/login
        [HttpPost("staff/login")]
        public IActionResult StaffLogin([FromBody] LoginRequest login)
        {
            // Dummy validation – replace with real authentication logic.
            if (login.Username == "staff" && login.Password == "staff123")
            {
                return Ok(new { Message = "Staff login successful", Role = "Staff" });
            }
            return Unauthorized("Invalid staff credentials.");
        }

        // POST: api/Auth/pharmacy/login
        [HttpPost("pharmacy/login")]
        public IActionResult PharmacyLogin([FromBody] LoginRequest login)
        {
            // Dummy validation – replace with real authentication logic.
            if (login.Username == "pharmacy" && login.Password == "pharmacy123")
            {
                return Ok(new { Message = "Pharmacy login successful", Role = "Pharmacy" });
            }
            return Unauthorized("Invalid pharmacy credentials.");
        }
    }
}
