using Microsoft.Extensions.DependencyInjection;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Extensions
{
    public static class AddAccountServices
    {
        public static void AddAccountServiceTypes(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountCreated, AccountCreatedService>();
            services.AddTransient<IAccountPortfolio, AccountPortfolioService>();
            services.AddTransient<IAccountBankDetailsUpdated, AccountBankUpdatedService>();
            services.AddTransient<IAccountIdentityUpdate, AccountIdentityUpdateService>();
        }
    }
}
