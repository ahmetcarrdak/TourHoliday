using System.Threading.Tasks;

namespace TourHoliday.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(string userId, bool isAgency = false);
        Task<string> AuthenticateUserAsync(string email, string password);
        Task<string> AuthenticateAgencyAsync(string email, string password);
    }
}