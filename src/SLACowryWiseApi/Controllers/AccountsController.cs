using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Accounts;
using System;
using System.Threading.Tasks;

namespace SLACowryWiseApi.Controllers
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountService _accountService;

        public AccountsController(ILogger<AccountsController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet("api/accounts/getaccount/{accountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAccount(string accountId)
        {
            try
            {
                if (string.IsNullOrEmpty(accountId)) return BadRequest(new { Message = "Account ID cannot be emtpy!" });
                var result = await _accountService.GetSingleAccount(accountId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpGet("api/accounts/getportfolio/{accountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAccountPortfolio(string accountId)
        {
            try
            {
                if (string.IsNullOrEmpty(accountId)) return BadRequest(new { Message = "Account ID cannot be emtpy!" });
                var result = await _accountService.GetPortfolio(accountId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error has occured, try your request later!");
            }
        }

        [HttpPost("api/accounts/createaccount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new { Message = "Request is in an inconsistent state!" });
                var result = await _accountService.CreateAccount(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error has occured, try your request later!");
            }
        }

        [HttpPost("api/accounts/updatenextofkin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateNextOfKin([FromBody] AccountNextOfKinInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new { Message = "Request is in an inconsistent state!" });
                var result = await _accountService.UpdateAccountNextOfKin(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error has occured, try your request later!");
            }
        }

        [HttpPost("api/accounts/updateprofile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOwnerAccountProfile([FromBody]
            UpdateProfileInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new { Message = "Request is in an inconsistent state!" });
                var result = await _accountService.UpdateAccountProfile(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error has occured, try your request later!");
            }
        }

        [HttpPost("api/accounts/updateaddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOwnerAccountAddress([FromBody]
            AddressUpdateInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new { Message = "Request is in an inconsistent state!" });
                var result = await _accountService.UpdateAccountAddress(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error has occured, try your request later!");
            }
        }

        [HttpPost("api/accounts/updateowneridentity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOwnerIdentity([FromBody] UpdateIdentityInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new { Message = "Request is in an inconsistent state!" });
                var result = await _accountService.UpdateAccountOwnerIdentity(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error has occured, try your request later!");
            }
        }

        [HttpPost("api/accounts/addbankaccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAccountWithBankDetails([FromBody] AddBankInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new { Message = "Request is in an inconsistent state!" });
                var result = await _accountService.UpdateBankDetails(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error has occured, try your request later!");
            }
        }
    }
}