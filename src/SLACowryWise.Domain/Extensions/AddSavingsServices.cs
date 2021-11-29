using Microsoft.Extensions.DependencyInjection;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Extensions
{
    public static class AddSavingsServices
    {
        public static void AddSavingsServiceTypes(this IServiceCollection services)
        {
            services.AddTransient<ISavingsService, SavingsService>();
            services.AddTransient<ICreateSavings, CreateSavingsService>();
            services.AddTransient<IFundSavings, FundSavingsService>();
            services.AddTransient<IWithdrawSavings, WithdrawSavingsService>();
        }
    }
}
