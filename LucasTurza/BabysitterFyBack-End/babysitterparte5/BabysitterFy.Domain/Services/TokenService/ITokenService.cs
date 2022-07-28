using BabysitterFy.Data.Models;

namespace BabysitterFy.Domain.Services.TokenService
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
