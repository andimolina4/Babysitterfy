using BabysitterFy.Data.Models;

namespace BabysitterFy.Domain.Services.TokenService
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
