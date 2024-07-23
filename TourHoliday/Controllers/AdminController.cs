using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourHoliday.Interfaces;
using TourHoliday.Models;

namespace TourHoliday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAdminsAsync();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdminById(int id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult> AddAdmin([FromBody] Admin admin)
        {
            if (admin == null)
            {
                return BadRequest();
            }

            await _adminService.AddAdminAsync(admin);
            return CreatedAtAction(nameof(GetAdminById), new { id = admin.Id }, admin);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdmin(int id, [FromBody] Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            await _adminService.UpdateAdminAsync(admin);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdmin(int id)
        {
            await _adminService.DeleteAdminAsync(id);
            return NoContent();
        }
    }
}