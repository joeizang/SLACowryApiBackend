using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Wallets;

namespace SLACowryWiseApi.Controllers
{
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly ILogger<WalletsController> _logger;
        private readonly IWalletService _walletService;

        public WalletsController(ILogger<WalletsController> logger, IWalletService walletService)
        {
            _logger = logger;
            _walletService = walletService;
        }
        [HttpGet("api/wallets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(WalletPaginatedDtoRoot))]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _walletService.GetAllWallets().ConfigureAwait(false);
                return result is not null ? Ok(result) : Ok(new WalletPaginatedDtoRoot());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }

        [HttpGet("api/wallets/{walletId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(SingleWalletResponse))]
        public async Task<IActionResult> GetSingleWallet(string walletId)
        {
            try
            {
                if (string.IsNullOrEmpty(walletId))
                    return BadRequest(new {Message = "Request must contain a valid wallet id!"});
                var result = await _walletService.GetAWallet(walletId).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }

        [HttpPost("api/wallets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(SingleWalletResponse))]
        public async Task<IActionResult> CreateWallet(CreateWalletInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new {Message = "The request is invalid!"});
                var result = await _walletService.CreateWallet(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }

        [HttpPost("api/wallets/transferfunds")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(SingleWalletResponse))]
        public async Task<IActionResult> TransferFunds(WalletTransferInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new {Message = "The request is invalid!"});
                var result = await _walletService.TransferFundsFromWallet(inputModel).ConfigureAwait(false);
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