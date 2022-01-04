using Microsoft.Extensions.DependencyInjection;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Services;

namespace SLACowryWise.Domain.Extensions
{
    public static class AddGeneralServices
    {
        public static void AddGeneralCowryServices(this IServiceCollection services)
        {
            services.AddTransient<ICacheBanksFromCowry, CacheBanksFromCowry>();
            services.AddTransient<IGeneralCowryService, GeneralCowryService>();
        }
    }
}
