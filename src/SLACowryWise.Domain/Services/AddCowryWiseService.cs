using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Configuration;

namespace SLACowryWise.Domain.Services
{
    public static class AddCowryWiseService
    {
        public static void AddCowryWise(this IServiceCollection services, IConfiguration configuration)
        {
            // services.Configure<AuthenticationConfiguration>(configuration.GetSection("CowryWiseSettings"))
            // services.AddHttpClient<IAuthenticationService, AuthenticationService>();
            // services.AddTransient<IRestClient>(opt => new RestClient(config.EndPointBaseUrl));
            // services.AddTransient<IAccountService, AccountService>();
            // services.AddTransient<IAuthenticationService, AuthenticationService>();
            // services.AddTransient<IWalletService, WalletService>();
            // services.AddTransient<IAssetsService, AssetsService>();
            // services.AddTransient<ISavingsService, SavingsService>();
            // services.AddTransient<IInvestmentService, InvestmentService>();
            // services.AddTransient<IHttpService, HttpService>();
        }
    }
}