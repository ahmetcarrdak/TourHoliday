using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TourHoliday.Interfaces;
using TourHoliday.Models;
using TourHoliday.Services;

public class AuthService : IAuthService
{
    private readonly string _key;
    private readonly string _issuer;
    private readonly string _userAudience;
    private readonly string _agencyAudience;
    private readonly int _expiresInMinutes;
    private readonly IUserService _userService;
    private readonly IAgencyService _agencyService;

    public AuthService(IConfiguration configuration, IUserService userService, IAgencyService agencyService)
    {
        _key = configuration["Jwt:Key"];
        _issuer = configuration["Jwt:Issuer"];
        _userAudience = configuration["Jwt:UserAudience"];
        _agencyAudience = configuration["Jwt:AgencyAudience"];
        _expiresInMinutes = int.Parse(configuration["Jwt:ExpiresInMinutes"]);
        _userService = userService;
        _agencyService = agencyService;
    }

    public string GenerateToken(string userId, bool isAgency = false)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_key);
        var audience = isAgency ? _agencyAudience : _userAudience;
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, userId)
            }),
            Expires = DateTime.UtcNow.AddMinutes(_expiresInMinutes),
            Issuer = _issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<string> AuthenticateUserAsync(string email, string password)
    {
        var user = await _userService.GetUserByEmailAsync(email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            return null;
        }

        return GenerateToken(user.Id.ToString());
    }

    public async Task<string> AuthenticateAgencyAsync(string email, string password)
    {
        var agency = await _agencyService.GetAgencyByEmailAsync(email);
        if (agency == null || !BCrypt.Net.BCrypt.Verify(password, agency.Password))
        {
            return null;
        }

        return GenerateToken(agency.Id.ToString(), true);
    }
}