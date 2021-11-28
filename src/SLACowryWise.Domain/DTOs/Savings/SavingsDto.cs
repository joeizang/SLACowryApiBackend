using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SLACowryWise.Domain.DTOs.Wallets;

namespace SLACowryWise.Domain.DTOs.Savings
{
    public class SavingsDto
    {
        [JsonPropertyName("savings_id")]
        public string SavingsId { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("principal")]
        public string Principal { get; set; }

        [JsonPropertyName("returns")]
        public string Returns { get; set; }

        [JsonPropertyName("balance")]
        public double Balance { get; set; }

        [JsonPropertyName("interest_enabled")]
        public bool InterestEnabled { get; set; }

        [JsonPropertyName("interest_rate")]
        public double InterestRate { get; set; }

        [JsonPropertyName("maturity_date")]
        public string MaturityDate { get; set; }

        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }
    }

    public class SingleSavingsResponse
    {
        [JsonPropertyName("data")]
        public SavingsDto Data { get; set; }

        [JsonPropertyName("errors")]
        public object Errors { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public class CreateSavingsResponse : DtoBase
    {
        [JsonPropertyName("data")]
        public SavingsDto Data { get; set; }
    }

    public class CreateSavingsInputModel
    {
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }
        [JsonPropertyName("days")]
        public string Days { get; set; }
        [JsonPropertyName("interest_enabled")]
        public string InterestEnabled { get; set; }
    }

    public class SavingsCreatedPayload
    {
        [JsonPropertyName("savings_id")]
        public string SavingsId { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("principal")]
        public string Principal { get; set; }

        [JsonPropertyName("returns")]
        public string Returns { get; set; }

        [JsonPropertyName("balance")]
        public string Balance { get; set; }

        [JsonPropertyName("interest_enabled")]
        public bool InterestEnabled { get; set; }

        [JsonPropertyName("interest_rate")]
        public string InterestRate { get; set; }

        [JsonPropertyName("maturity_date")]
        public string MaturityDate { get; set; }

        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }
    }

    public class SavingsCreatedResponseDto : DtoBase
    {
        [JsonPropertyName("data")]
        public SavingsCreatedPayload Data { get; set; }
    }
    
    public class SavingsPagination
    {
        [JsonPropertyName("next")]
        public object Next { get; set; }

        [JsonPropertyName("previous")]
        public object Previous { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }

    public class SavingsDataPayload
    {
        [JsonPropertyName("savings_id")]
        public string SavingsId { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("principal")]
        public string Principal { get; set; }

        [JsonPropertyName("returns")]
        public string Returns { get; set; }

        [JsonPropertyName("balance")]
        public string Balance { get; set; }

        [JsonPropertyName("interest_enabled")]
        public bool InterestEnabled { get; set; }

        [JsonPropertyName("interest_rate")]
        public double InterestRate { get; set; }

        [JsonPropertyName("maturity_date")]
        public string MaturityDate { get; set; }

        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }
    }

    public class SavingsPaginatedResponseDto
    {
        [JsonPropertyName("pagination")]
        public SavingsPagination Pagination { get; set; }

        [JsonPropertyName("data")]
        public List<SavingsDataPayload> Data { get; set; }

        [JsonPropertyName("errors")]
        public object Errors { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
    
    public class SingleSavingsByIdPayload
    {
        [JsonPropertyName("savings_id")]
        public string SavingsId { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("principal")]
        public string Principal { get; set; }

        [JsonPropertyName("returns")]
        public string Returns { get; set; }

        [JsonPropertyName("balance")]
        public string Balance { get; set; }

        [JsonPropertyName("interest_enabled")]
        public bool InterestEnabled { get; set; }

        [JsonPropertyName("interest_rate")]
        public double InterestRate { get; set; }

        [JsonPropertyName("maturity_date")]
        public string MaturityDate { get; set; }

        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }
    }

    public class SingleSavingsByIdResponseDto
    {
        [JsonPropertyName("data")]
        public SingleSavingsByIdPayload Data { get; set; }

        [JsonPropertyName("errors")]
        public object Errors { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
    
    public class SavingsRatePayload
    {
        [JsonPropertyName("interest_rate")]
        public string InterestRate { get; set; }

        [JsonPropertyName("tenure")]
        public string Tenure { get; set; }
    }

    public class FundSavingsPayload
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("amount")]
        public Amount Amount { get; set; }

        [JsonPropertyName("fee")]
        public Fee Fee { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("source_asset")]
        public SourceAsset SourceAsset { get; set; }

        [JsonPropertyName("destination_asset")]
        public DestinationAsset DestinationAsset { get; set; }

        [JsonPropertyName("transfer_type")]
        public string TransferType { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; set; }
    }

    public class FundSavingsDtoResponse : DtoBase
    {
        [JsonPropertyName("data")]
        public FundSavingsPayload Data { get; set; }
    }
    
    public class SavingsRateDtoResponse : DtoBase
    {
        [JsonPropertyName("data")]
        public SavingsRatePayload Data { get; set; }
    }

    public class WithdrawFromSavingsDto
    {
        [JsonPropertyName("successful")]
        public bool Successful { get; set; }
    }

    public class WithdrawFromSavingsInputModel
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }
        
        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("savings_id")]
        public string SavingsId { get; set; }
    }

    public class FundSavingsAmount
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public class FundSavingsFee
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public class FundSavingsSourceAsset
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("account_name")]
        public string AccountName { get; set; }

        [JsonPropertyName("account_email")]
        public string AccountEmail { get; set; }

        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("asset_type")]
        public string AssetType { get; set; }
    }

    public class FundSavingsDestinationAsset
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("account_name")]
        public string AccountName { get; set; }

        [JsonPropertyName("account_email")]
        public string AccountEmail { get; set; }

        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("asset_type")]
        public string AssetType { get; set; }
    }

   

}