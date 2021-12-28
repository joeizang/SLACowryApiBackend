using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLACowryWise.Domain;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SLACowryWiseApi.Controllers
{
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IGeneralCowryService _service;

        public BanksController(IGeneralCowryService service)
        {
            _service = service;
        }
        // GET: api/<Banks>
        [HttpGet("api/banks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(BankResponse))]
        public async Task<IActionResult> Get([FromQuery] GetPaginatedResponseInputModel model)
        {
            var result = await _service.GetBanks(model).ConfigureAwait(false);
            return Ok(result);
        }

    }
}
