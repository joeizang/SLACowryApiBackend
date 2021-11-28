using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DTOs.Accounts
{
    public class AddressUpdateInputModel
    {
        public string AccountID { get; set; }
        public string Street { get; set; }
        public string Lga { get; set; }
        public string AreaCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class AccountNextOfKinInputModel
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("gender")]
        public string Email { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("relationship")]
        public string Relationship { get; set; }
        [JsonPropertyName("phonenumber")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("accountId")]
        public string AccountID { get; set; }
    }

    public class UpdateProfileInputModel
    {
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }
        
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
        
        [JsonPropertyName("accountId")]
        public string AccountID { get; set; }
        
        [JsonPropertyName("date_of_birth")]
        public string DateOfBirth { get; set; }
    }

    public class UpdateIdentityInputModel
    {
        [JsonPropertyName("identity_type")]
        public string IdentityType { get; set; }
        
        [JsonPropertyName("identity_value")]
        public string IdentityValue { get; set; }
        
        [JsonPropertyName("accountId")]
        public string AccountID { get; set; }
    }
    
    public class IdentityUpdatePayload
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("verification_status")]
        public string VerificationStatus { get; set; }
    }

    public class AccountIdentityResponse : DtoBase
    {
        [JsonPropertyName("data")]
        public IdentityUpdatePayload Data { get; set; }
    }

    public class AddBankInputModel
    {
        [JsonPropertyName("bank_code")]
        public string BankCode { get; set; }
        
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }
        
        [JsonPropertyName("accountId")]
        public string AccountID { get; set; }
    }
    
    public class AccountBankUpdatePayload
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("account_name")]
        public string AccountName { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("bank_name")]
        public string BankName { get; set; }

        [JsonPropertyName("bank_code")]
        public string BankCode { get; set; }
    }

    public class AccountBankUpdateResponse : DtoBase
    {
        [JsonPropertyName("data")]
        public AccountBankUpdatePayload Data { get; set; }
    }

    public class CreateAccountInputModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }

    public class GetById
    {
        public string Id { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }

        public string Lga { get; set; }

        public string AreaCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
    }

    public class NextOfKin
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Relationship { get; set; }

        public string Gender { get; set; }
    }

    public class AccountCreationPayload
    {
        [JsonPropertyName("account_id")] public string AccountId { get; set; }

        [JsonPropertyName("account_number")] public int AccountNumber { get; set; }

        [JsonPropertyName("first_name")] public string FirstName { get; set; }

        [JsonPropertyName("last_name")] public string LastName { get; set; }

        [JsonPropertyName("email")] public string Email { get; set; }

        [JsonPropertyName("risk_appetite")] public int RiskAppetite { get; set; }

        [JsonPropertyName("is_proprietary")] public bool IsProprietary { get; set; }

        [JsonPropertyName("account_status")] public string AccountStatus { get; set; }

        [JsonPropertyName("verification_status")] public string VerificationStatus { get; set; }

        [JsonPropertyName("is_verified")] public bool IsVerified { get; set; }

        [JsonPropertyName("account_type")] public string AccountType { get; set; }

        [JsonPropertyName("phone_number")] public object PhoneNumber { get; set; }

        [JsonPropertyName("date_of_birth")] public object DateOfBirth { get; set; }

        [JsonPropertyName("gender")] public object Gender { get; set; }

        [JsonPropertyName("identifications")] public List<object> Identifications { get; set; }

        [JsonPropertyName("banks")] public List<object> Banks { get; set; }

        [JsonPropertyName("address")] public Address Address { get; set; }

        [JsonPropertyName("next_of_kin")] public NextOfKin NextOfKin { get; set; }

        [JsonPropertyName("date_joined")] public DateTime DateJoined { get; set; }
    }
    
    public class Balance
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("portfolio_returns")]
        public string PortfolioReturns { get; set; }
    }

    public class AccountWallet
    {
        [JsonPropertyName("wallet_id")]
        public string WalletId { get; set; }

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

        [JsonPropertyName("lifetime_returns")]
        public string LifetimeReturns { get; set; }

        [JsonPropertyName("balance")]
        public string Balance { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("account_name")]
        public string AccountName { get; set; }

        [JsonPropertyName("bank_name")]
        public string BankName { get; set; }

        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }
    }

    public class AccountAssets
    {
        [JsonPropertyName("wallets")]
        public List<AccountWallet> Wallets { get; set; }

        [JsonPropertyName("savings")]
        public List<object> Savings { get; set; }

        [JsonPropertyName("indexes")]
        public List<object> Indexes { get; set; }

        [JsonPropertyName("mutual_funds")]
        public List<object> MutualFunds { get; set; }

        [JsonPropertyName("treasury_bills")]
        public List<object> TreasuryBills { get; set; }

        [JsonPropertyName("stocks")]
        public List<object> Stocks { get; set; }
    }

    public class AccountPortfolioPayload
    {
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("balance")]
        public List<Balance> Balance { get; set; }

        [JsonPropertyName("assets")]
        public AccountAssets Assets { get; set; }
    }

    public class AccountPortfolioResponse : DtoBase
    {
        [JsonPropertyName("data")]
        public AccountPortfolioPayload Data { get; set; }
    }



    public class AccountCreationResponse : DtoBase
    {
        [JsonPropertyName("data")] public AccountCreationPayload Data { get; set; }
    }
}