using Microsoft.Extensions.DependencyInjection;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Services;

namespace SLACowryWise.Domain.Extensions
{
    public static class AddSettlementServices
    {
        public static void AddSettlementService(this IServiceCollection services)
        {
            services.AddTransient<ISettlementService, SettlementService>();
            services.AddTransient<IWithdrawToUserBank, WithdrawToUserBankService>();
        }
    }
}
