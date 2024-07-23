using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourHoliday.Interfaces;
using TourHoliday.Models;

namespace TourHoliday.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgenciesController : ControllerBase
    {
        private readonly IAgencyService _agencyService;

        public AgenciesController(IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agency>>> GetAgencies()
        {
            var agencies = await _agencyService.GetAllAgenciesAsync();
            return Ok(agencies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agency>> GetAgency(int id)
        {
            var agency = await _agencyService.GetAgencyByIdAsync(id);
            if (agency == null) return NotFound();
            return Ok(agency);
        }

        [HttpPost]
        public async Task<ActionResult<Agency>> CreateAgency(Agency agency)
        {
            await _agencyService.AddAgencyAsync(agency);
            return CreatedAtAction(nameof(GetAgency), new { id = agency.Id }, agency);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgency(int id, Agency agency)
        {
            if (id != agency.Id) return BadRequest("Agency ID mismatch");

            try
            {
                await _agencyService.UpdateAgencyAsync(agency);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgency(int id)
        {
            try
            {
                await _agencyService.DeleteAgencyAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
