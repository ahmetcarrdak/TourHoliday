using System.Threading.Tasks;

namespace TourHoliday.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(string userId);
        Task<string> AuthenticateUserAsync(string username, string password);
        Task<string> AuthenticateAgencyAsync(string username, string password);
    }
}