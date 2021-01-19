using PandemiC.Client.Models;

namespace PandemiC.API.Infrastructure.Security
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        User ValidateToken(string token);
    }
}