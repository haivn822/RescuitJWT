using Rescuit.API.Models;

namespace Rescuit.API.Repository
{
    public interface ITokenRepository
    {
        Tokens Authenticate(Users users);
    }
}
