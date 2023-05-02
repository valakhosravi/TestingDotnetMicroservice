using Auth.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Auth.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto model);
        Task<SignInResult> LoginAsync(LoginDto model);
        Task LogoutAsync();
    }

}
