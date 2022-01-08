using Microsoft.Extensions.DependencyInjection;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Services;

namespace SLACowryWise.Domain.Extensions
{
    public static class AddInvestmentServices
    {
        public static void AddInvestmentTypesService(this IServiceCollection services)
        {
            services.AddTransient<IInvestmentService, InvestmentService>();
            services.AddTransient<ICreateInvestment, InvestmentCreatedService>();
            services.AddTransient<ILiquidateInvestment, LiquidateInvestmentService>();
            services.AddTransient<IInvestmentFunded, InvestmentFundedService>();
            services.AddTransient<ICachedAssetsService, CachedAssetsService>();
            services.AddTransient<IAssetsService, AssetsService>();
        }
    }
}
