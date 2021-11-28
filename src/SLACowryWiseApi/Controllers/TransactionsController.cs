using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using SLACowryWise.Domain;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Transactions;

namespace SLACowryWiseApi.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly ITransactionService _service;

        public TransactionsController(ILogger<TransactionsController> logger, ITransactionService service)
        {
            _logger = logger;
            _service = service;
        }
        // GET: api/Transactions
        [HttpGet("transfer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(GetTransactionsPaginatedResponse))]
        public async Task<ActionResult<GetTransactionsPaginatedResponse>> GetTransactions([FromQuery]GetAllTransfersInputModel inputModel)
        {
            var result = await _service.GetAllTransfers(inputModel).ConfigureAwait(false);
            return Ok(result) ?? Ok(new GetTransactionsPaginatedResponse());
        }

        // GET: api/Transactions/5
        [HttpGet("deposits")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(GetDepositsPaginatedResponse))]
        public async Task<ActionResult<GetDepositsPaginatedResponse>> GetDeposits([FromQuery] GetPaginatedResponseInputModel inputModel)
        {
            var result = await _service.GetAllDeposits(inputModel).ConfigureAwait(false);
            return Ok(result) ?? Ok(new GetDepositsPaginatedResponse());
        }

        [HttpGet("withdrawals")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(typeof(GetAllWithdrawalsPaginatedResponse))]
        public async Task<ActionResult<GetAllWithdrawalsPaginatedResponse>> GetWithdrawals(
            [FromQuery] GetPaginatedResponseInputModel inputModel)
        {
            var result = await _service.GetAllWithdrawals(inputModel).ConfigureAwait(false);
            return Ok(result) ?? Ok(new GetAllWithdrawalsPaginatedResponse());
        }
    }
}
