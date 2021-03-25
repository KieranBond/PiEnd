using Api.Common;

namespace DiscordBot
{
    public interface IDiscordBotFacade : IFacade
    {
        DiscordBotStatusDto GetStatus();
        DiscordBotStatusDto StartBot();
        DiscordBotStatusDto StopBot();
    }
}
