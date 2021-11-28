using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Assets;

namespace SLACowryWiseApi.Controllers
{
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly ILogger<AssetsController> _logger;
        private readonly IAssetsService _assetsService;

        public AssetsController(ILogger<AssetsController> logger, IAssetsService assetsService)
        {
            _logger = logger;
            _assetsService = assetsService;
        }
        
        [HttpGet("api/assets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(AssetsPaginatedResponse))]
        public async Task<IActionResult> Index()
        {
            var result = await _assetsService.GetAllAssets().ConfigureAwait(false);
            return result is not null ? Ok(result) : Ok(new AssetsPaginatedResponse());
        }

        [HttpGet("api/assets/{assetId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(AssetsPaginatedResponse))]
        public async Task<IActionResult> GetAnAsset(string assetId)
        {
            try
            {
                if (string.IsNullOrEmpty(assetId)) return BadRequest(new {Message = "The request is invalid!"});
                var result = await _assetsService.GetSingleAsset(assetId).ConfigureAwait(false);
                return  Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("An error occured and your request cannot be fulfilled, please try later!");
            }
        }
    }
}