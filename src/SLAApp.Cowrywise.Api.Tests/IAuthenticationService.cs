using System.Threading.Tasks;

namespace SLAApp.Cowrywise.Api.Tests
{
    public interface IAuthenticationService
    {
        Task<IAuthenticationService> GetApiToken();

        Task RefreshToken();

        ApiToken ApiToken { get; }
    }
}