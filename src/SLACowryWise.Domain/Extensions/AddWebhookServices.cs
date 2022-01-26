using Microsoft.Extensions.DependencyInjection;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DomainModels.WebhookPayloads;
using SLACowryWise.Domain.Services;

namespace SLACowryWise.Domain.Extensions
{
    public static class AddWebhookServices
    {
        public static void AddWebhookPersistenceServices(this IServiceCollection services)
        {
            services.AddTransient<IMongodbWebhookService<WebhookResponse>, MongodbWebhookService<WebhookResponse>>();
            //services.AddTransient<IMongodbWebhookService<AccountCreatedWebhookPayload>, AccountWebhookService>();
            //services.AddTransient<IMongodbWebhookService<IndexCreatedUpdatedWebhookPayload>, IndexWebhookService>();
            //services.AddTransient<IMongodbWebhookService<InvestmentCreatedWebhookPayload>, InvestmentCreatedWebhookService>();
            //services.AddTransient<IMongodbWebhookService<InvestmentUpdatedWebhookPayload>, InvestmentUpdatedWebhookService>();
            //services.AddTransient<IMongodbWebhookService<LiquidationCreatedWebhookPayload>, LiquidationWebhookService>();
            //services.AddTransient<IMongodbWebhookService<SavingsCreatedWebhookPayload>, SavingsCreatedWebhookService>();
            //services.AddTransient<IMongodbWebhookService<SavingsUpdatedWebhookPayload>, SavingsUpdatedWebhookService>();
            //services.AddTransient<IMongodbWebhookService<SettlementCreatedWebhookPayload>, SettlementCreatedWebhookService>();
            //services.AddTransient<IMongodbWebhookService<SettlementSuccessfulWebhookPayload>, SettlementSuccessfulWebhookService>();
            //services.AddTransient<IMongodbWebhookService<TransferCreatedWebhookPayload>, TransferCreatedWebhookService>();
            //services.AddTransient<IMongodbWebhookService<WalletCreatedCreditedWebhookPayload>, WalletCreatedWebhookService>();
        }
    }
}
