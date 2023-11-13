using Microsoft.AspNetCore.Identity;

namespace PracticeUdemy.Repository
{
    public interface IAuthentication
    {
        string CreateJwtToken(IdentityUser identityUser, List<string> roles);
    }
}
