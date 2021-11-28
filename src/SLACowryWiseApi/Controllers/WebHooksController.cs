using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.WebHookUtilities;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SLACowryWiseApi.Controllers
{
    [Route("hooks")]
    public class WebHooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly SignatureGenerator _generator;

        public WebHooksController(IMediator mediator, SignatureGenerator generator)
        {
            _mediator = mediator;
            _generator = generator;
        }


        [HttpPost]
        public async Task<IActionResult> SubscribeToWebHooks()
        {
            var signature = "";
            var temp = new object();
            using(var reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                temp = JsonSerializer.Deserialize<object>(body);
            }

            if(_generator.PrepSignature().Equals(signature))
            {
                //await _mediator.Publish(model as IWebhookPayload); 
                Console.WriteLine(temp);
                return Ok();
            }
            else
            {
                throw new Exception("Altered webhook");
            }
        }
    }
}