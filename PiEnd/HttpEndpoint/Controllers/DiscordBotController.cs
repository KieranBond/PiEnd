using Api.Common;
using DiscordBot;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Annotations;

namespace PiEnd.HttpEndpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class DiscordBotController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IDiscordBotFacade _facade;

        public DiscordBotController(ILogger logger, IDiscordBotFacade facade)
        {
            _logger = logger;
            _facade = facade;
        }

        [HttpGet]
        [Route("status")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK)]
        public ActionResult<DiscordBotStatusDto> Get()
        {
            _logger.LogInformation("Received {0}/{1}", nameof(Get), nameof(DiscordBotStatusDto));

            var status = _facade.GetStatus();
            return Ok(status);
        }

        [HttpPut]
        [Route("status/start")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest)]
        public ActionResult<DiscordBotStatusDto> Start()
        {
            _logger.LogInformation("Received {0}/{1}.", nameof(Start), nameof(DiscordBotStatusDto));

            var status = _facade.StartBot();

            return Ok(status);
        }

        [HttpPut]
        [Route("status/stop")]
        [SwaggerResponse(System.Net.HttpStatusCode.OK)]
        [SwaggerResponse(System.Net.HttpStatusCode.BadRequest)]
        public ActionResult<DiscordBotStatusDto> Stop()
        {
            _logger.LogInformation("Received {0}/{1}.", nameof(Stop), nameof(DiscordBotStatusDto));

            var status = _facade.StopBot();

            return Ok(status);
        }

    }
}
