using CarConnect.Entities;
using CarConnect.Helpers;
using CarConnect.Models.Account;
using CarConnect.Repository.Users;
using System.Security.Claims;

namespace CarConnect.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AccountService> _logger;
        public AccountService(IUserRepository userRepository, ILogger<AccountService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<ClaimsIdentity> Register(RegisterViewModel model)
        {
            try
            {
                // var user = await _userRepository.Getll().FirstOrDefaultAsync(x => x.Name == model.Name);
                var user = (await _userRepository.FindAsync(x => x.Name == model.Name)).FirstOrDefault();
                if (user != null)
                {
                    return null;
                }

                user = new User()
                {
                    Name = model.Name,
                    Password = EncryptionHelper.HashPassword(model.Password),
                };

                await _userRepository.AddAsync(user);

                var result = Authenticate(user);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Register]: {ex.Message}");
                return null;
            }
        }

        public async Task<ClaimsIdentity> Login(LoginViewModel model)
        {
            try
            {
                var user = (await _userRepository.FindAsync(x => x.Name == model.Name)).FirstOrDefault();
                if (user == null)
                {
                    return null;
                }

                if (user.Password != EncryptionHelper.HashPassword(model.Password))
                {
                    return null;
                }
                var result = Authenticate(user);

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Login]: {ex.Message}");
                return null;
            }
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
