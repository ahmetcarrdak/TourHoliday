using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourHoliday.Data;
using TourHoliday.Interfaces;
using TourHoliday.Models;

namespace TourHoliday.Services
{
    public class AgencySaleTourService : IAgencySaleTourService
    {
        private readonly ApplicationDbContext _context;

        public AgencySaleTourService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AgencySaleTour>> GetAllAgencySaleToursAsync()
        {
            return await _context.AgencySaleTours.ToListAsync();
        }

        public async Task<AgencySaleTour> GetAgencySaleTourByIdAsync(int id)
        {
            return await _context.AgencySaleTours.FindAsync(id);
        }

        public async Task AddAgencySaleTourAsync(AgencySaleTour agencySaleTour)
        {
            _context.AgencySaleTours.Add(agencySaleTour);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAgencySaleTourAsync(AgencySaleTour agencySaleTour)
        {
            _context.Entry(agencySaleTour).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAgencySaleTourAsync(int id)
        {
            var agencySaleTour = await _context.AgencySaleTours.FindAsync(id);
            if (agencySaleTour != null)
            {
                _context.AgencySaleTours.Remove(agencySaleTour);
                await _context.SaveChangesAsync();
            }
        }
    }
}