namespace SLACowryWise.Domain.DomainModels.WebhookPayloads
{
    public class CowryWebHookEvent
    {
        // Account_Created
        // Savings_Created
        // Savings_Updated,
        // Wallet_Created,
        // Wallet_Credited,
        // Investment_Created,
        // Investment_Updated,
        // Index_Created,
        // Index_updated,
        // Transfer_Failed,
        // Liquidation_Created
        public string WebHookEventName { get; set; }
        public string Description { get; set; }
    }
}