using System.Threading.Tasks;
using SLACowryWise.Domain.Configuration;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IAuthenticationService
    {
        Task<IAuthenticationService> GetApiToken();

        Task RefreshToken();

        ApiToken ApiToken { get; }
    }
}