using System.Collections.Generic;
using System.Threading.Tasks;
using TourHoliday.Models;

namespace TourHoliday.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<Admin> GetAdminByIdAsync(int id);
        Task AddAdminAsync(Admin admin);
        Task UpdateAdminAsync(Admin admin);
        Task DeleteAdminAsync(int id);
    }
}