using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourHoliday.Data;
using TourHoliday.Interfaces;
using TourHoliday.Models;

namespace TourHoliday.Services
{
    public class AgencyService : IAgencyService
    {
        private readonly ApplicationDbContext _context;

        public AgencyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Agency>> GetAllAgenciesAsync()
        {
            return await _context.Agencies.ToListAsync();
        }

        public async Task<Agency> GetAgencyByIdAsync(int id)
        {
            return await _context.Agencies.FindAsync(id);
        }
        
        public async Task<Agency> GetAgencyByEmailAsync(string email)
        {
            return await _context.Agencies.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task AddAgencyAsync(Agency agency)
        {
            _context.Agencies.Add(agency);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAgencyAsync(Agency agency)
        {
            _context.Entry(agency).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAgencyAsync(int id)
        {
            var agency = await _context.Agencies.FindAsync(id);
            if (agency != null)
            {
                _context.Agencies.Remove(agency);
                await _context.SaveChangesAsync();
            }
        }
    }
}