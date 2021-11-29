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
    public static class AddWalletServices
    {
        public static void AddWalletServiceTypes(this IServiceCollection services)
        {
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<ICreateWallet, CreateWalletService>();
            services.AddTransient<IFundsWalletTransfer, FundsWalletTransferService>();
        }
    }
}
