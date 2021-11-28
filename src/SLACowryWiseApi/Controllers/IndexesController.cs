using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLACowryWise.Domain;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Indexes;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SLACowryWiseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexesController : ControllerBase
    {
        private IIndex _indexService;

        public IndexesController(IIndex indexService)
        {
            _indexService = indexService;
        }
        // GET: api/<IndexesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(IndexPaginatedResponse))]
        public async Task<IActionResult> GetIndexes([FromQuery]GetPaginatedResponseInputModel inputModel)
        {
            var result = await _indexService.GetIndexes(inputModel).ConfigureAwait(false);
            return result is not null ? Ok(result) : Ok(new IndexPaginatedResponse());
        }

        // GET api/<IndexesController>/5
        [HttpGet("{indexId}/assets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(IndexAssetsResponse))]
        public async Task<IActionResult> GetIndexAssets(string indexId)
        {
            try
            {
                var result = await _indexService.GetIndexAssets(indexId).ConfigureAwait(false);
                return result is not null ? Ok(result) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{indexId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(SingleIndexResponse))]
        public async Task<IActionResult> GetIndexById(string indexId)
        {
            try
            {
                var result = await _indexService.GetSingleIndex(indexId).ConfigureAwait(false);
                return result is not null ? Ok(result) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<IndexesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(CustomIndexResponse))]
        public async Task<IActionResult> CreateCustomIndex([FromBody] CustomIndexInputModel inputModel)
        {
            if (inputModel is null && !ModelState.IsValid)
            {
                return BadRequest($"Your request is in an inconsistent state, please check for submission again!");
            }

            try
            {
                var result = await _indexService.CreateCustomIndex(inputModel).ConfigureAwait(false);
                return result is not null ? Ok(result) : BadRequest("Index creation was not successful!!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT api/<IndexesController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(UpdateCustomIndexResponse))]
        public async Task<IActionResult> ModifyCustomIndex([FromBody] UpdateCustomIndexInputModel inputModel)
        {
            if(inputModel is null && !ModelState.IsValid)
            {
                return BadRequest("Your request is in an inconsistent state, check your update submission!");
            }

            try
            {
                var result = await _indexService.UpdateCustomIndex(inputModel).ConfigureAwait(false);
                return result is not null ? Ok(result) : BadRequest("Update was unsuccessful!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
