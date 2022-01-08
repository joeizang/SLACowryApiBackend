using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Assets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SLACowryWiseApi.Controllers
{
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly ILogger<AssetsController> _logger;
        private readonly IAssetsService _assetsService;
        private readonly ICachedAssetsService _cachedAssets;

        public AssetsController(ILogger<AssetsController> logger, IAssetsService assetsService, ICachedAssetsService cachedAssets)
        {
            _logger = logger;
            _assetsService = assetsService;
            _cachedAssets = cachedAssets;
        }

        [HttpGet("api/assets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(AssetsPaginatedResponse))]
        public async Task<IActionResult> Index([FromQuery] AssetsPaginatedResponseInput query)
        {
            var result = await _assetsService.GetAllAssets(query).ConfigureAwait(false);
            return result is not null ? Ok(result) : Ok(new AssetsPaginatedResponse());
        }

        [HttpGet("api/cachedassets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(List<SingleAssetsResponse>))]
        public async Task<IActionResult> GetCachedAssets()
        {
            var result = await _assetsService.GetCahedAssets().ConfigureAwait(false);
            return result is not null ? Ok(result) : Ok(new List<SingleAssetsResponse>());
        }

        [HttpGet("api/assets/{assetId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(AssetsPaginatedResponse))]
        public async Task<IActionResult> GetAnAsset(string assetId)
        {
            try
            {
                if (string.IsNullOrEmpty(assetId)) return BadRequest(new { Message = "The request is invalid!" });
                var result = await _assetsService.GetSingleAsset(assetId).ConfigureAwait(false);
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