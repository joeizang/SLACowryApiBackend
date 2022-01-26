using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DomainModels.WebhookPayloads;
using SLACowryWise.Domain.WebHookUtilities;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SLACowryWiseApi.Controllers
{
    [Route("api/hooks")]
    [ApiController]
    public class WebHooksController : ControllerBase
    {
        private readonly IMongodbWebhookService<WebhookResponse> _webhookService;
        private readonly ISignatureGenerator _generator;

        public WebHooksController(ISignatureGenerator generator, IMongodbWebhookService<WebhookResponse> webhookService)
        {
            _generator = generator;
            _webhookService = webhookService;
        }


        [HttpPost]
        public async Task<IActionResult> SubscribeToWebHooks()
        {
            var response = new WebhookResponse();
            var hash = _generator.PrepSignature();
            using (var reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                response = JsonSerializer.Deserialize<WebhookResponse>(body);
            }

            if (hash == response.Event.Signature)
            {
                await _webhookService.CreateOneAsync(response).ConfigureAwait(false);
                Console.WriteLine(response);
                return Ok();
            }
            else
            {
                response.Message = $"Illegal attempt on webhook at {DateTimeOffset.UtcNow}";
                await _webhookService.CreateOneAsync(response).ConfigureAwait(false);
                return Ok();
            }
        }
    }
}