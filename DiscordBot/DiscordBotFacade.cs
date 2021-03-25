using Microsoft.Extensions.Logging;

namespace DiscordBot
{
    public class DiscordBotFacade : IDiscordBotFacade
    {
        private ILogger _logger;
        private DiscordBotStatusDto _botStatus;

        public DiscordBotFacade(ILogger logger)
        {
            _logger = logger;
            _botStatus = new DiscordBotStatusDto(false);
        }

        public DiscordBotStatusDto GetStatus()
        {
            return _botStatus;
        }

        public DiscordBotStatusDto StartBot()
        {
            _botStatus = new DiscordBotStatusDto(true);
            return _botStatus;
        }

        public DiscordBotStatusDto StopBot()
        {
            _botStatus = new DiscordBotStatusDto(false);
            return _botStatus;
        }
    }
}
