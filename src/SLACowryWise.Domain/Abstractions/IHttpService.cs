using RestSharp;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IHttpService
    {
        Task<RestClient> InitializeClient();
    }
}