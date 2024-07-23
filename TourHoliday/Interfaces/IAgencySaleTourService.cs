using System.Collections.Generic;
using System.Threading.Tasks;
using TourHoliday.Models;

namespace TourHoliday.Interfaces
{
    public interface IAgencySaleTourService
    {
        Task<IEnumerable<AgencySaleTour>> GetAllAgencySaleToursAsync();
        Task<AgencySaleTour> GetAgencySaleTourByIdAsync(int id);
        Task AddAgencySaleTourAsync(AgencySaleTour agencySaleTour);
        Task UpdateAgencySaleTourAsync(AgencySaleTour agencySaleTour);
        Task DeleteAgencySaleTourAsync(int id);
    }
}