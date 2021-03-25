using Akka.Actor;
using Microsoft.Extensions.Logging;
using System;

namespace DiscordBot.Actors
{
    public class DiscordBotSupervisor : ReceiveActor
    {
        private readonly ILogger _logger;

        public DiscordBotSupervisor(ILogger logger)
        {
            _logger = logger;

            _logger.LogInformation("Discord Bot Super spinning up");

            Setup();
        }

        private void Setup()
        {
        }
    }
}
