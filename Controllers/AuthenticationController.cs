using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mid_assignment_backend.Models;
using mid_assignment_backend.Repositories;
using mid_assignment_backend.Services;

namespace mid_assignment_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
    {
        _logger = logger;
        _authenticationService = authenticationService;
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] AuthenticationRequest model)
    {
        var response = await _authenticationService.Login(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }


}


