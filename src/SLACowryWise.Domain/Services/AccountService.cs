using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Data;
using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs.Accounts;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpService _service;
        private readonly IAccountCreated _mongo;
        private readonly IAccountIdentityUpdate _identity;
        private readonly IAccountBankDetailsUpdated _bank;
        private readonly IAccountProfile _profile;
        private readonly IAccountNextOfKinUpdate _nextOfKin;
        private readonly IAccountAddressUpdates _addressUpdates;

        public AccountService(IHttpService service,
            IAccountCreated mongo,
            IAccountIdentityUpdate identity,
            IAccountBankDetailsUpdated bank,
            IAccountNextOfKinUpdate nextOfKin,
            IAccountProfile accountProfile,
            IAccountAddressUpdates addressUpdates)
        {
            _service = service;
            _mongo = mongo;
            _identity = identity;
            _bank = bank;
            _profile = accountProfile;
            _nextOfKin = nextOfKin;
            _addressUpdates = addressUpdates;
        }
        public async Task<AccountPortfolioResponse> GetPortfolio(string id)
        {
            IRestRequest request = new RestRequest($"/api/v1/accounts/{id}", Method.GET);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<AccountPortfolioResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<AccountCreationResponse> UpdateAccountAddress(AddressUpdateInputModel inputModel)
        {
            IRestRequest request = new RestRequest($"/api/v1/accounts/{inputModel.AccountID}/address", Method.POST);
            request.AddParameter("area_code", inputModel.AreaCode, ParameterType.GetOrPost);
            request.AddParameter("lga", inputModel.Lga, ParameterType.GetOrPost);
            request.AddParameter("state", inputModel.State, ParameterType.GetOrPost);
            request.AddParameter("city", inputModel.City, ParameterType.GetOrPost);
            request.AddParameter("country", inputModel.Country, ParameterType.GetOrPost);
            request.AddParameter("street", inputModel.Street, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<AccountCreationResponse>(request)
                .ConfigureAwait(false);
            var addyUpdates = new AccountAddressUpdates
            {
                AddressUpdate = result.Data
            };
            await _addressUpdates.CreateOneAsync(addyUpdates).ConfigureAwait(false);
            return result.Data;
        }

        public async Task<AccountCreationResponse> CreateAccount(CreateAccountInputModel inputModel)
        {
            IRestRequest request = new RestRequest("/api/v1/accounts", Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("first_name", inputModel.FirstName, ParameterType.GetOrPost);
            request.AddParameter("last_name", inputModel.LastName, ParameterType.GetOrPost);
            request.AddParameter("email", inputModel.Email, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<AccountCreationResponse>(request)
                .ConfigureAwait(false);

            var acctCreated = new AccountCreated
            {
                AccountCreationDto = result.Data
            };
            await _mongo.CreateOneAsync(acctCreated).ConfigureAwait(false);
            return result.Data;
        }

        public async Task<AccountCreationResponse> GetSingleAccount(string id)
        {
            IRestRequest request = new RestRequest($"/api/v1/accounts/{id}", Method.GET);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<AccountCreationResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<AccountCreationResponse> UpdateAccountNextOfKin(AccountNextOfKinInputModel inputModel)
        {
            IRestRequest request = new RestRequest($"/api/v1/accounts/{inputModel.AccountID}/nok", Method.POST);
            request.AddParameter("email", inputModel.Email, ParameterType.GetOrPost);
            request.AddParameter("last_name", inputModel.LastName, ParameterType.GetOrPost);
            request.AddParameter("first_name", inputModel.FirstName, ParameterType.GetOrPost);
            request.AddParameter("phone_number", inputModel.PhoneNumber, ParameterType.GetOrPost);
            request.AddParameter("gender", inputModel.Gender, ParameterType.GetOrPost);
            request.AddParameter("date_of_birth", inputModel.Relationship, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<AccountCreationResponse>(request)
                .ConfigureAwait(false);
            var nextOfKin = new AccountNextOfKinUpdate
            {
                UpdateNextOfKin = result.Data
            };
            await _nextOfKin.CreateOneAsync(nextOfKin).ConfigureAwait(false);
            return result.Data;
        }

        public async Task<AccountCreationResponse> UpdateAccountProfile(UpdateProfileInputModel inputModel)
        {
            IRestRequest request = new RestRequest($"/api/v1/accounts/{inputModel.AccountID}/profile", Method.POST);
            request.AddParameter("email", inputModel.Email, ParameterType.GetOrPost);
            request.AddParameter("last_name", inputModel.LastName, ParameterType.GetOrPost);
            request.AddParameter("first_name", inputModel.FirstName, ParameterType.GetOrPost);
            request.AddParameter("phone_number", inputModel.PhoneNumber, ParameterType.GetOrPost);
            request.AddParameter("gender", inputModel.Gender, ParameterType.GetOrPost);
            request.AddParameter("date_of_birth", inputModel.DateOfBirth, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<AccountCreationResponse>(request)
                .ConfigureAwait(false);
            var acctProfile = new AccountProfile
            {
                AccountProfileDto = result.Data
            };
            await _profile.CreateOneAsync(acctProfile).ConfigureAwait(false);
            return result.Data;
        }

        public async Task<AccountIdentityResponse> UpdateAccountOwnerIdentity(UpdateIdentityInputModel inputModel)
        {
            IRestRequest request = new RestRequest($"/api/v1/accounts/{inputModel.AccountID}/identity", Method.POST);
            request.AddParameter("identity_type", inputModel.IdentityType, ParameterType.GetOrPost);
            request.AddParameter("identity_value", inputModel.IdentityValue, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<AccountIdentityResponse>(request)
                .ConfigureAwait(false);
            var identityUpdate = new AccountIdentityUpdate
            {
                AccountIdentityDto = result.Data
            };
            await _identity.CreateOneAsync(identityUpdate).ConfigureAwait(false);
            return result.Data;
        }

        public async Task<AccountBankUpdateResponse> UpdateBankDetails(AddBankInputModel inputModel)
        {
            IRestRequest request = new RestRequest($"/api/v1/accounts/{inputModel.AccountID}/bank", Method.POST);
            request.AddParameter("identity_type", inputModel.BankCode, ParameterType.GetOrPost);
            request.AddParameter("identity_value", inputModel.AccountNumber, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<AccountBankUpdateResponse>(request)
                .ConfigureAwait(false);
            var bankUpdate = new AccountBankUpdate
            {
                AccountBankUpdateDto = result.Data
            };
            await _bank.CreateOneAsync(bankUpdate).ConfigureAwait(false);
            return result.Data;
        }
    }

    public class AccountCreatedService : MongodbPersistenceService<AccountCreated>, IAccountCreated
    {
        public AccountCreatedService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class AccountBankUpdatedService : MongodbPersistenceService<AccountBankUpdate>, IAccountBankDetailsUpdated
    {
        public AccountBankUpdatedService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class AccountIdentityUpdateService : MongodbPersistenceService<AccountIdentityUpdate>, IAccountIdentityUpdate
    {
        public AccountIdentityUpdateService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class AccountProfileService : MongodbPersistenceService<AccountProfile>, IAccountProfile
    {
        public AccountProfileService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class AccountNextOfKinUpdateService : MongodbPersistenceService<AccountNextOfKinUpdate>, IAccountNextOfKinUpdate
    {
        public AccountNextOfKinUpdateService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class AccountAddressUpdatesService : MongodbPersistenceService<AccountAddressUpdates>, IAccountAddressUpdates
    {
        public AccountAddressUpdatesService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }
}