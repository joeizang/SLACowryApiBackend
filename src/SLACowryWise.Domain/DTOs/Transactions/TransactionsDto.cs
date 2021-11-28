#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DTOs.Transactions
{
    public class TransactionAmount
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public class TransactionSourceAccount
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

    public class TransactionDestinationAccount
    {
        [JsonPropertyName("asset_type")]
        public string AssetType { get; set; }

        [JsonPropertyName("bank")]
        public string Bank { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("account_name")]
        public string AccountName { get; set; }
    }

    public class DepositPayload
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("amount")]
        public TransactionAmount Amount { get; set; }

        [JsonPropertyName("source")]
        public TransactionSourceAccount Source { get; set; }

        [JsonPropertyName("destination")]
        public TransactionDestinationAccount Destination { get; set; }

        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; set; }
    }

    public class GetDepositResponse
    {
        [JsonPropertyName("data")]
        public DepositPayload Deposit { get; set; }
    }

    public class WithdrawalSourceAccount
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

    public class WithdrawalDestinationAccount
    {
        [JsonPropertyName("asset_type")]
        public string AssetType { get; set; }

        [JsonPropertyName("bank")]
        public string Bank { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("account_name")]
        public string AccountName { get; set; }
    }

    public class GetWithdrawalPayload
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("amount")]
        public TransactionAmount Amount { get; set; }

        [JsonPropertyName("source")]
        public WithdrawalSourceAccount Source { get; set; }

        [JsonPropertyName("destination")]
        public WithdrawalDestinationAccount Destination { get; set; }

        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; set; }
    }

    public class GetWithdrawalResponse
    {
        [JsonPropertyName("data")]
        public GetWithdrawalPayload Data { get; set; }
    }
    
    public class Fee
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public class TransactionSourceAsset
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

    public class TransactionDestinationAsset
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

    public class SingleTransferPayload
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("amount")]
        public TransactionAmount Amount { get; set; }

        [JsonPropertyName("fee")]
        public Fee Fee { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("source_asset")]
        public TransactionSourceAsset SourceAsset { get; set; }

        [JsonPropertyName("destination_asset")]
        public TransactionDestinationAsset DestinationAsset { get; set; }

        [JsonPropertyName("transfer_type")]
        public string TransferType { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; set; }
    }

    public class SingleTransferResponse
    {
        [JsonPropertyName("data")]
        public SingleTransferPayload Data { get; set; }

        [JsonPropertyName("errors")]
        public object Errors { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
    
    public class Pagination
    {
        [JsonPropertyName("next")]
        public object Next { get; set; }

        [JsonPropertyName("previous")]
        public object Previous { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }

    public class GetAllTransactionsPayload
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("amount")]
        public TransactionAmount Amount { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("source_asset")]
        public TransactionSourceAsset SourceAsset { get; set; }

        [JsonPropertyName("destination_asset")]
        public TransactionDestinationAsset DestinationAsset { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("fee")]
        public double Fee { get; set; }

        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; set; }
    }

    public class GetTransactionsPaginatedResponse
    {
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }

        [JsonPropertyName("data")]
        public List<GetAllTransactionsPayload> Data { get; set; }

        [JsonPropertyName("errors")]
        public string? Errors { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }

    public class GetAllTransfersInputModel
    {
        [JsonPropertyName("asset_type")]
        public string? AssetType { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("page")]
        public string? Page { get; set; }

        [JsonPropertyName("page_size")]
        public string? PageSize { get; set; }
        
        [JsonPropertyName("account_id")]
        public string? AccountId { get; set; }

        [JsonPropertyName("transfer_type")]
        public string? TransferType { get; set; }

        [JsonPropertyName("from_date")]
        public string? FromDate { get; set; }

        [JsonPropertyName("to_date")]
        public string? ToDate { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }
    
    public class GetDepositsPaginatedPayload
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("amount")]
        public TransactionAmount Amount { get; set; }

        [JsonPropertyName("source")]
        public TransactionSourceAccount Source { get; set; }

        [JsonPropertyName("destination")]
        public TransactionDestinationAccount Destination { get; set; }

        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; set; }
    }

    public class GetDepositsPaginatedResponse
    {
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }

        [JsonPropertyName("data")]
        public List<GetDepositsPaginatedPayload> Data { get; set; }

        [JsonPropertyName("errors")]
        public object Errors { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
    
    public class GetWithdrawalPaginatedPayload
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("amount")]
        public TransactionAmount Amount { get; set; }

        [JsonPropertyName("source")]
        public TransactionSourceAccount Source { get; set; }

        [JsonPropertyName("destination")]
        public TransactionDestinationAccount Destination { get; set; }

        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; set; }
    }

    public class GetAllWithdrawalsPaginatedResponse
    {
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }

        [JsonPropertyName("data")]
        public List<GetWithdrawalPaginatedPayload> Data { get; set; }

        [JsonPropertyName("errors")]
        public object Errors { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}