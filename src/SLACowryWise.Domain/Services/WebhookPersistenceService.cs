using SLACowryWise.Domain.Data;
using SLACowryWise.Domain.DomainModels.WebhookPayloads;

namespace SLACowryWise.Domain.Services
{
    public class AccountWebhookService : MongodbWebhookService<AccountCreatedWebhookPayload>
    {
        public AccountWebhookService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class IndexWebhookService : MongodbWebhookService<IndexCreatedUpdatedWebhookPayload>
    {
        public IndexWebhookService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class InvestmentCreatedWebhookService : MongodbWebhookService<InvestmentCreatedWebhookPayload>
    {
        public InvestmentCreatedWebhookService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class InvestmentUpdatedWebhookService : MongodbWebhookService<InvestmentUpdatedWebhookPayload>
    {
        public InvestmentUpdatedWebhookService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class LiquidationWebhookService : MongodbWebhookService<LiquidationCreatedWebhookPayload>
    {
        public LiquidationWebhookService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class SavingsCreatedWebhookService : MongodbWebhookService<SavingsCreatedWebhookPayload>
    {
        public SavingsCreatedWebhookService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class SavingsUpdatedWebhookService : MongodbWebhookService<SavingsUpdatedWebhookPayload>
    {
        public SavingsUpdatedWebhookService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class SettlementCreatedWebhookService : MongodbWebhookService<SettlementCreatedWebhookPayload>
    {
        public SettlementCreatedWebhookService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class SettlementSuccessfulWebhookService : MongodbWebhookService<SettlementSuccessfulWebhookPayload>
    {
        public SettlementSuccessfulWebhookService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class TransferCreatedWebhookService : MongodbWebhookService<TransferCreatedWebhookPayload>
    {
        public TransferCreatedWebhookService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class WalletCreatedWebhookService : MongodbWebhookService<WalletCreatedCreditedWebhookPayload>
    {
        public WalletCreatedWebhookService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }
}
