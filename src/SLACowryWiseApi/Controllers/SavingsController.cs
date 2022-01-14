using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Savings;
using SLACowryWise.Domain.DTOs.Wallets;
using System;
using System.Threading.Tasks;

namespace SLACowryWiseApi.Controllers
{
    [ApiController]
    public class SavingsController : ControllerBase
    {
        private readonly ILogger<SavingsController> _logger;
        private readonly ISavingsService _savingsService;

        public SavingsController(ILogger<SavingsController> logger, ISavingsService savingsService)
        {
            _logger = logger;
            _savingsService = savingsService;
        }

        [HttpGet("api/savings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(SavingsPaginatedResponseDto))]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _savingsService.GetAllSavings().ConfigureAwait(false);
                return result is not null ? Ok(result) : Ok(new SavingsPaginatedResponseDto());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }

        [HttpGet("api/savings/{savingsId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(SingleSavingsByIdResponseDto))]
        public async Task<IActionResult> GetASaving(string savingsId)
        {
            try
            {
                if (string.IsNullOrEmpty(savingsId)) return BadRequest(new { Message = "The request is invalid!" });
                var result = await _savingsService.GetSingleSavings(savingsId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }

        [HttpPost("api/savings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(CreateSavingsResponse))]
        public async Task<IActionResult> CreateSavings([FromBody] CreateSavingsInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new { Message = "The request is invalid!" });
                var result = await _savingsService.CreateSavings(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }

        [HttpPost("api/savings/{savingsId}/fund", Name = "FundSavings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(FundSavingsDtoResponse))]
        public async Task<IActionResult> FundSavingsFromWallet(string savingsId, [FromBody] WalletTransferInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new { Message = "The request is invalid!" });
                var result = await _savingsService.FundSavingsFromWallet(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }

        [HttpPost("api/savings/{savingsId}/withdraw", Name = "SavingsWithdrawal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(WithdrawFromSavingsDto))]
        public async Task<IActionResult> WithdrawFromSavings(string savingsId, [FromBody] WithdrawFromSavingsInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new { Message = "The request is invalid!" });
                if (string.IsNullOrEmpty(savingsId))
                    return BadRequest(new { Message = "The request must come with a valid savings id!" });
                inputModel.SavingsId = savingsId;
                var result = await _savingsService.WithdrawFromSavings(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }

        [HttpPost("api/savings/rates", Name = "GetSavingsRates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(SavingsRateDtoResponse))]
        public async Task<IActionResult> GetSavingsRates(string days)
        {
            try
            {
                if (string.IsNullOrEmpty(days)) return BadRequest(new { Message = "The request is invalid!" });
                var result = await _savingsService.GetSavingsRate(days).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }
    }
}