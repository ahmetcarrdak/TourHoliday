using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TourHoliday.Interfaces;
using TourHoliday.Models;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login/User")]
    public async Task<IActionResult> LoginUser([FromBody] Auth model)
    {
        var token = await _authService.AuthenticateUserAsync(model.Username, model.Password);
        if (token == null)
        {
            return Unauthorized();
        }

        return Ok(new { Token = token });
    }

    [HttpPost("login/Agency")]
    public async Task<IActionResult> LoginAgency([FromBody] Auth model)
    {
        var token = await _authService.AuthenticateAgencyAsync(model.Username, model.Password);
        if (token == null)
        {
            return Unauthorized();
        }

        return Ok(new { Token = token });
    }

}