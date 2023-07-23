using CarConnect.Models.Account;
using System.Security.Claims;

namespace CarConnect.Services.Accounts
{
    public interface IAccountService
    {
        Task<ClaimsIdentity> Register(RegisterViewModel model);
        Task<ClaimsIdentity> Login(LoginViewModel model);

    }
}
