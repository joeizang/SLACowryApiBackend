using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SLACowryWise.Domain;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Wallets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index([FromQuery] GetPaginatedResponseInputModel query)
        {
            try
            {
                var result = await _walletService.GetAllWallets(query).ConfigureAwait(false);
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
                    return BadRequest(new { Message = "Request must contain a valid wallet id!" });
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
        public async Task<IActionResult> CreateWallet([FromBody] CreateWalletInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new { Message = "The request is invalid!" });
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
        public async Task<IActionResult> TransferFunds([FromBody] WalletTransferInputModel inputModel)
        {
            try
            {
                if (inputModel is null) return BadRequest(new { Message = "The request is invalid!" });
                var result = await _walletService.TransferFundsFromWallet(inputModel).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }

        [HttpGet("api/wallets/{accountId}/getwalletids")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(List<string>))]
        public async Task<IActionResult> GetWalletIds(string accountId)
        {
            if (accountId is null) return BadRequest(new { Message = "users cowry account id cannot be emtpy!" });
            var result = await _walletService.ReturnWalletIdsByAccountId(accountId).ConfigureAwait(false);
            return Ok(result);
        }
    }
}