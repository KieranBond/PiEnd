namespace DiscordBot
{
    public class DiscordBotStatusDto
    {
        public bool IsRunning { get; private set; }

        public DiscordBotStatusDto(bool isRunning)
        {
            IsRunning = isRunning;
        }
    }
}
