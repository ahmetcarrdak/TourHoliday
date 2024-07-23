using System.Collections.Generic;
using System.Threading.Tasks;
using TourHoliday.Models;

namespace TourHoliday.Interfaces
{
    public interface IAgencyService
    {
        Task<IEnumerable<Agency>> GetAllAgenciesAsync();
        Task<Agency> GetAgencyByIdAsync(int id);
        Task AddAgencyAsync(Agency agency);
        Task UpdateAgencyAsync(Agency agency);
        Task DeleteAgencyAsync(int id);
        Task<Agency> GetAgencyByEmailAsync(string email);
    }
}