using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Assets;
using SLACowryWise.Domain.DTOs.Investments;
using SLACowryWise.Domain.DTOs.Wallets;

namespace SLACowryWiseApi.Controllers
{
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private readonly ILogger<InvestmentsController> _logger;
        private readonly IInvestmentService _investmentService;

        public InvestmentsController(ILogger<InvestmentsController> logger, IInvestmentService investmentService)
        {
            _logger = logger;
            _investmentService = investmentService;
        }
        
        [HttpGet("api/investments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(InvestmentPaginatedDtoResponse))]
        public async Task<IActionResult> Index([FromQuery] InvestmentPaginatedResponseInput inputModel)
        {
            var result = await _investmentService
                .GetAllInvestments(inputModel)
                .ConfigureAwait(false);
            return result is not null ? Ok(result) : Ok(new AssetsPaginatedResponse());
        }
        
        [HttpGet("api/investments/{investmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(SingleInvestmentResponseDto))]
        public async Task<IActionResult> GetAnAsset(string investmentId)
        {
            try
            {
                if (string.IsNullOrEmpty(investmentId)) return BadRequest(new {Message = "The request is invalid!"});
                var result = await _investmentService.GetSingleInvestment(investmentId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }
        
        [HttpPost("api/investments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(SingleInvestmentResponseDto))]
        public async Task<IActionResult> CreateWallet(CreateInvestmentInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new {Message = "The request is invalid!"});
                var result = await _investmentService.CreateInvestment(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }
        
        [HttpPost("api/investments/{investmentId}/transfer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(TransferFromWalletResponseDto))]
        public async Task<IActionResult> FundInvestment(string investmentId, WalletTransferInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new {Message = "The request is invalid!"});
                if (string.IsNullOrEmpty(investmentId))
                    return BadRequest(new {Message = "A valid investment Id must accompany this request!"});
                inputModel.AccountId = investmentId;
                var result = await _investmentService.FundInvestment(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }
        
        [HttpPost("api/investments/{investmentId}/liquidate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(InvestmentLiquidatedDto))]
        public async Task<IActionResult> LiquidateInvestment(string investmentId, string units)
        {
            try
            {
                if (string.IsNullOrEmpty(units)) return BadRequest(new {Message = "The request is invalid!"});
                if (string.IsNullOrEmpty(investmentId)) return BadRequest(new {Message = "The request is invalid!"});
                var result = await _investmentService.LiquidateInvestment(units, investmentId).ConfigureAwait(false);
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