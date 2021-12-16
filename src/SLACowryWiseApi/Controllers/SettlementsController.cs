using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SLACowryWise.Domain.Abstractions;

namespace SLACowryWiseApi.Controllers
{
    [ApiController]
    [Route("api/settlements")]
    public class SettlementsController : ControllerBase
    {
        private readonly ILogger<SettlementsController> _logger;
        private readonly ISettlementService _service;

        public SettlementsController(ILogger<SettlementsController> logger, ISettlementService service)
        {
            _logger = logger;
            _service = service;
        }
        
        [HttpPost("api/settlements/withdrawtobank")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(SettlementResponseDto))]
        public async Task<ActionResult<SettlementResponseDto>> DrawToBank([FromBody] SettlementInputModel model)
        {
            try
            {
                if (model is null)
                    return BadRequest(new {Message = "Request is invalid!"});
                var result = await _service.WithdrawToUserBankAccount(model).ConfigureAwait(false);
                if (string.IsNullOrEmpty(result.Data.Id) || result.Errors is not null)
                {
                    return BadRequest(new {Message = "There was an error, please retry the request later!"});
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}