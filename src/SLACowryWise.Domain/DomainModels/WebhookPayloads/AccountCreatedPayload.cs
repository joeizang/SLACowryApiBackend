using MediatR;
using SLACowryWise.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DomainModels.WebhookPayloads
{
    public class AccountCreatedPayload : IWebhookPayload
    {
        [JsonPropertyName("event")] public AccountCreatedEvent Event { get; set; }

        [JsonPropertyName("data")] public AccountCreatedEventPayloadData Payload { get; set; }

        
    }

    public class AccountCreatedEvent
    {
        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("event")] public string EventName { get; set; }

        [JsonPropertyName("target")] public string Target { get; set; }

        [JsonPropertyName("signature")] public string Signature { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("street")] public string Street { get; set; }

        [JsonPropertyName("lga")] public string Lga { get; set; }

        [JsonPropertyName("area_code")] public string AreaCode { get; set; }

        [JsonPropertyName("city")] public string City { get; set; }

        [JsonPropertyName("state")] public string State { get; set; }

        [JsonPropertyName("country")] public object Country { get; set; }
    }

    public class NextOfKin
    {
        [JsonPropertyName("first_name")] public string FirstName { get; set; }

        [JsonPropertyName("last_name")] public string LastName { get; set; }

        [JsonPropertyName("email")] public string Email { get; set; }

        [JsonPropertyName("phone_number")] public string PhoneNumber { get; set; }

        [JsonPropertyName("relationship")] public string Relationship { get; set; }

        [JsonPropertyName("gender")] public object Gender { get; set; }
    }

    public class AccountCreatedEventPayloadData
    {
        [JsonPropertyName("account_id")] public string AccountId { get; set; }

        [JsonPropertyName("account_number")] public int AccountNumber { get; set; }

        [JsonPropertyName("first_name")] public string FirstName { get; set; }

        [JsonPropertyName("last_name")] public string LastName { get; set; }

        [JsonPropertyName("email")] public string Email { get; set; }

        [JsonPropertyName("risk_appetite")] public int RiskAppetite { get; set; }

        [JsonPropertyName("is_proprietary")] public bool IsProprietary { get; set; }

        [JsonPropertyName("account_status")] public string AccountStatus { get; set; }

        [JsonPropertyName("verification_status")]
        public string VerificationStatus { get; set; }

        [JsonPropertyName("is_verified")] public bool IsVerified { get; set; }

        [JsonPropertyName("account_type")] public string AccountType { get; set; }

        [JsonPropertyName("phone_number")] public object PhoneNumber { get; set; }

        [JsonPropertyName("date_of_birth")] public object DateOfBirth { get; set; }

        [JsonPropertyName("gender")] public object Gender { get; set; }

        [JsonPropertyName("identifications")] public List<object> Identifications { get; set; }

        [JsonPropertyName("address")] public Address Address { get; set; }

        [JsonPropertyName("next_of_kin")] public NextOfKin NextOfKin { get; set; }

        [JsonPropertyName("date_joined")] public DateTime DateJoined { get; set; }
    }
}