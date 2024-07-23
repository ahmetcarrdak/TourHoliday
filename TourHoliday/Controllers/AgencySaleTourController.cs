using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourHoliday.Interfaces;
using TourHoliday.Models;

namespace TourHoliday.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgencySaleToursController : ControllerBase
    {
        private readonly IAgencySaleTourService _agencySaleTourService;

        public AgencySaleToursController(IAgencySaleTourService agencySaleTourService)
        {
            _agencySaleTourService = agencySaleTourService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgencySaleTour>>> GetAgencySaleTours()
        {
            var agencySaleTours = await _agencySaleTourService.GetAllAgencySaleToursAsync();
            return Ok(agencySaleTours);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgencySaleTour>> GetAgencySaleTour(int id)
        {
            var agencySaleTour = await _agencySaleTourService.GetAgencySaleTourByIdAsync(id);
            if (agencySaleTour == null) return NotFound();
            return Ok(agencySaleTour);
        }

        [HttpPost]
        public async Task<ActionResult<AgencySaleTour>> CreateAgencySaleTour(AgencySaleTour agencySaleTour)
        {
            await _agencySaleTourService.AddAgencySaleTourAsync(agencySaleTour);
            return CreatedAtAction(nameof(GetAgencySaleTour), new { id = agencySaleTour.Id }, agencySaleTour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgencySaleTour(int id, AgencySaleTour agencySaleTour)
        {
            if (id != agencySaleTour.Id) return BadRequest("AgencySaleTour ID mismatch");

            try
            {
                await _agencySaleTourService.UpdateAgencySaleTourAsync(agencySaleTour);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencySaleTour(int id)
        {
            try
            {
                await _agencySaleTourService.DeleteAgencySaleTourAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
