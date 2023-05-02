using Auth.DTOs;
using Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        var result = await _accountService.RegisterAsync(model);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(result.Errors);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var result = await _accountService.LoginAsync(model);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest("Invalid login attempt.");
    }

    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await _accountService.LogoutAsync();
        return Ok();
    }
}
