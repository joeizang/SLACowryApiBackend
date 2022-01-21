using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Accounts;
using SLACowryWise.Domain.Services;

namespace SLACowryWise.Domain.DomainModels
{
    [BsonCollection("AccountsCreated")]
    public class AccountCreated : BaseDomainModel
    {
        public RestResponse<AccountCreationResponse> AccountCreationDto { get; set; }

        public CreateAccountInputModel Request { get; set; }
    }

    [BsonCollection("AccountsProfile")]
    public class AccountProfile : BaseDomainModel
    {
        public RestResponse<AccountCreationResponse> AccountProfileDto { get; set; }
        public UpdateProfileInputModel Request { get; internal set; }
    }

    [BsonCollection("AccountsBankUpdate")]
    public class AccountBankUpdate : BaseDomainModel
    {
        public RestResponse<AccountBankUpdateResponse> AccountBankUpdateDto { get; set; }
        public AddBankInputModel Request { get; internal set; }
    }

    [BsonCollection("AccountsIdentityUpate")]
    public class AccountIdentityUpdate : BaseDomainModel
    {
        public RestResponse<AccountIdentityResponse> AccountIdentityDto { get; set; }
        public UpdateIdentityInputModel Request { get; internal set; }
    }

    [BsonCollection("AccountsNextOfKin")]
    public class AccountNextOfKinUpdate : BaseDomainModel
    {
        public RestResponse<AccountCreationResponse> UpdateNextOfKin { get; set; }
        public AccountNextOfKinInputModel Request { get; internal set; }
    }

    [BsonCollection("AccountAddressUpdates")]
    public class AccountAddressUpdates : BaseDomainModel
    {
        public RestResponse<AccountCreationResponse> AddressUpdate { get; set; }
        public AddressUpdateInputModel Request { get; internal set; }
    }

}
