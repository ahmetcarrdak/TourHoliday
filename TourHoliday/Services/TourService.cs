using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourHoliday.Data;
using TourHoliday.Interfaces;
using TourHoliday.Models;

namespace TourHoliday.Services
{
    public class TourService : ITourService
    {
        private readonly ApplicationDbContext _context;

        public TourService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tour>> GetAllToursAsync()
        {
            return await _context.Tours.ToListAsync();
        }

        public async Task<Tour> GetTourByIdAsync(int id)
        {
            return await _context.Tours.FindAsync(id);
        }

        public async Task AddTourAsync(Tour tour)
        {
            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTourAsync(Tour tour)
        {
            _context.Entry(tour).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTourAsync(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                await _context.SaveChangesAsync();
            }
        }
    }
}