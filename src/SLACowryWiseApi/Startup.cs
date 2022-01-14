using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SLACowryWise.Domain;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Configuration;
using SLACowryWise.Domain.Data;
using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.Extensions;
using SLACowryWise.Domain.Services;
using SLACowryWise.Domain.WebHookUtilities;
using System.Text.Json;
using System.Text.Json.Serialization;

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

            services.Configure<MongoDatabaseSettings>(Configuration.GetSection("MongodbConnectionSettings"));
            services.AddSingleton<IMongoDatabaseSettings, MongoDatabaseSettings>(st =>
                st.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);
            services.AddScoped<IMongodbService<AccountCreated>, MongodbPersistenceService<AccountCreated>>();

            services.Configure<AuthenticationConfiguration>(Configuration.GetSection("CowryWiseSettings"));
            services.AddHttpClient();
            services.AddHttpClient<IAuthenticationService, AuthenticationService>();
            //services.AddTransient(opt => new RestClient("https://sandbox.embed.cowrywise.com"));
            services.AddTransient<IHttpService, HttpService>();
            services.AddAccountServiceTypes();
            services.AddInvestmentTypesService();
            services.AddSavingsServiceTypes();
            services.AddWalletServiceTypes();
            services.AddGeneralCowryServices();

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAssetsService, AssetsService>();
            services.AddTransient<ISettlementService, SettlementService>();
            services.AddTransient<ITransactionService, TransactionsService>();
            services.AddTransient<IIndex, IndexService>();
            services.AddTransient<ITradeStockService, TradeStockService>();
            services.AddScoped<ISignatureGenerator, SignatureGenerator>();
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SLACowryWiseApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "SLACowryWiseApi v1"));
            }

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "SLACowryWiseApi v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}