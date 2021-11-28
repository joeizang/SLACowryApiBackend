using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RestSharp;
using SLACowryWise.Domain;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Configuration;
using SLACowryWise.Domain.Data;
using SLACowryWise.Domain.Services;
using SLACowryWise.Domain.WebHookUtilities;

namespace SLACowryWiseApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SlaCowryWiseContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.Configure<AuthenticationConfiguration>(Configuration.GetSection("CowryWiseSettings"));
            services.AddHttpClient();
            services.AddHttpClient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IRestClient>(opt => new RestClient("https://sandbox.embed.cowrywise.com"));
            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<IAssetsService, AssetsService>();
            services.AddTransient<ISavingsService, SavingsService>();
            services.AddTransient<IInvestmentService, InvestmentService>();
            services.AddTransient<ISettlementService, SettlementService>();
            services.AddTransient<ITransactionService, TransactionsService>();
            services.AddTransient<IIndex, IndexService>();
            services.AddTransient<ITradeStockService, TradeStockService>();
            services.AddTransient<SignatureGenerator>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "SLACowryWiseApi", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SLACowryWiseApi v1"));
            }

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SLACowryWiseApi v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}