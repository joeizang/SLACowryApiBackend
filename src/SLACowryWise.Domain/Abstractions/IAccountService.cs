using System.Threading.Tasks;
using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs.Accounts;

namespace SLACowryWise.Domain.Abstractions
{
    public interface IAccountService
    {
        /// <summary>
        /// Show account portfolio performance
        /// </summary>
        /// <param name="id">ID of account</param>
        /// <returns>AccountPortfolioDto</returns>
        Task<AccountPortfolioResponse> GetPortfolio(string id);
        
        /// <summary>
        /// Updates the given address that belongs to an account
        /// </summary>
        /// <param name="inputModel">Dto that holds the values to update the address</param>
        /// <returns>AccountCreationDto</returns>
        Task<AccountCreationResponse> UpdateAccountAddress(AddressUpdateInputModel inputModel);
        
        /// <summary>
        /// Create new account, also called an investment account
        /// </summary>
        /// <param name="inputModel">Dto to holds values to create account</param>
        /// <returns>AccountCreationDto</returns>
        Task<AccountCreationResponse> CreateAccount(CreateAccountInputModel inputModel);
        
        /// <summary>
        /// Get a single Account provided an account Id is provided
        /// </summary>
        /// <param name="id">string account id</param>
        /// <returns>AccountCreationDto</returns>
        Task<AccountCreationResponse> GetSingleAccount(string id);

        /// <summary>
        /// Update Next of Kin data attached to account
        /// </summary>
        /// <param name="inputModel">InputModel of type AccountNextOfKinInputModel</param>
        /// <returns>AccountCreationDto</returns>
        Task<AccountCreationResponse> UpdateAccountNextOfKin(AccountNextOfKinInputModel inputModel);

        /// <summary>
        /// Update Profile of Account
        /// </summary>
        /// <param name="inputModel">InputModel of type UpdateProfileInputModel</param>
        /// <returns>AccountCreationDto</returns>
        Task<AccountCreationResponse> UpdateAccountProfile(UpdateProfileInputModel inputModel);

        /// <summary>
        /// Update Identification attached to account
        /// </summary>
        /// <param name="inputModel">InputModel of type UpdateIdentityInputModel</param>
        /// <returns>AccountIdentityDto</returns>
        Task<AccountIdentityResponse> UpdateAccountOwnerIdentity(UpdateIdentityInputModel inputModel);

        /// <summary>
        /// Update bank account details attached with account
        /// </summary>
        /// <param name="inputModel">InputModel of type AddBankInputModel</param>
        /// <returns>AccountBankUpdateDto</returns>
        Task<AccountBankUpdateResponse> UpdateBankDetails(AddBankInputModel inputModel);
    }

    public interface IAccountIdentityUpdate : IMongodbService<AccountIdentityUpdate> { }

    public interface IAccountPortfolio : IMongodbService<AccountPortfolio> { }

    public interface IAccountCreated : IMongodbService<AccountCreated> { }

    public interface IAccountBankDetailsUpdated : IMongodbService<AccountBankUpdate> { }
}