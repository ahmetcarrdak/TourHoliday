using System.Collections.Generic;
using System.Threading.Tasks;
using TourHoliday.Models;

namespace TourHoliday.Interfaces
{
    public interface ITourService
    {
        Task<IEnumerable<Tour>> GetAllToursAsync();
        Task<Tour> GetTourByIdAsync(int id);
        Task AddTourAsync(Tour tour);
        Task UpdateTourAsync(Tour tour);
        Task DeleteTourAsync(int id);
    }
}