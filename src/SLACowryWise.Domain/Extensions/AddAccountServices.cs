using Microsoft.Extensions.DependencyInjection;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Services;

namespace SLACowryWise.Domain.Extensions
{
    public static class AddAccountServices
    {
        public static void AddAccountServiceTypes(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountCreated, AccountCreatedService>();
            services.AddTransient<IAccountProfile, AccountProfileService>();
            services.AddTransient<IAccountBankDetailsUpdated, AccountBankUpdatedService>();
            services.AddTransient<IAccountIdentityUpdate, AccountIdentityUpdateService>();
            services.AddTransient<IAccountAddressUpdates, AccountAddressUpdatesService>();
            services.AddTransient<IAccountNextOfKinUpdate, AccountNextOfKinUpdateService>();
        }
    }
}
