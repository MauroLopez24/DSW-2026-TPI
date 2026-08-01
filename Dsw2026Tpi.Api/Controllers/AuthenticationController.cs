using Dsw2026Tpi.Application.Dtos;
using Dsw2026Tpi.Application.Interfaces;
<<<<<<< HEAD
=======
using Dsw2026Tpi.CrossCutting.Identity;
>>>>>>> development
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Dsw2026Tpi.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthenticationController : AppController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("admin/register")]
<<<<<<< HEAD
    [EnableRateLimiting("GeneralPolicy")]
=======
    [AllowAnonymous]
>>>>>>> development
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterModel.Request request)
    {
        var result = await _authenticationService.Register(request);
        return Ok(result.Email);
    }

    [HttpPost("admin/login")]
<<<<<<< HEAD
    [EnableRateLimiting("AdminLoginPolicy")]
    [AllowAnonymous]
=======
    [AllowAnonymous]
    [EnableRateLimiting(RateLimitPolices.AdminLogin)]
>>>>>>> development
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> LoginAdmin([FromBody] LoginAdminModel.Request request)
    {
        var result = await _authenticationService.LoginAdmin(request);
        return Ok(result);
    }
<<<<<<< HEAD

    [HttpPost("patient/login")]
    [EnableRateLimiting("PatientLoginPolicy")]
    [AllowAnonymous]
=======
    [HttpPost("patient/login")]
    [AllowAnonymous]
    [EnableRateLimiting(RateLimitPolices.PatientLogin)]
>>>>>>> development
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LoginPatient([FromBody] LoginPatientModel.Request request)
    {
        var result = await _authenticationService.LoginPatient(request);
        return Ok(result);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> development
