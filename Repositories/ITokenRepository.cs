using Microsoft.AspNetCore.Identity;

namespace training.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
