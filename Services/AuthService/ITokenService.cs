using Entities;

namespace Services.ProductDataServices
{
    public interface ITokenService
    {
        string GetToken(User user);
    }
}
