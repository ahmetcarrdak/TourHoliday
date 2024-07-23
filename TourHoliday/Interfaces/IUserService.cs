using System.Collections.Generic;
using System.Threading.Tasks;
using TourHoliday.Models;

namespace TourHoliday.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
    }
}