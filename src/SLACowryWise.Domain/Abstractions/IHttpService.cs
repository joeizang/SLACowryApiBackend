using System.Threading.Tasks;
using RestSharp;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IHttpService
    {
        Task<IRestClient> InitializeClient();
    }
}