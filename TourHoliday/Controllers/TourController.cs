using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourHoliday.Interfaces;
using TourHoliday.Models;

namespace TourHoliday.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToursController : ControllerBase
    {
        private readonly ITourService _tourService;

        public ToursController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTours()
        {
            var tours = await _tourService.GetAllToursAsync();
            return Ok(tours);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(int id)
        {
            var tour = await _tourService.GetTourByIdAsync(id);
            if (tour == null) return NotFound();
            return Ok(tour);
        }

        [HttpPost]
        public async Task<ActionResult<Tour>> CreateTour(Tour tour)
        {
            await _tourService.AddTourAsync(tour);
            return CreatedAtAction(nameof(GetTour), new { id = tour.Id }, tour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTour(int id, Tour tour)
        {
            if (id != tour.Id) return BadRequest("Tour ID mismatch");

            try
            {
                await _tourService.UpdateTourAsync(tour);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int id)
        {
            try
            {
                await _tourService.DeleteTourAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}