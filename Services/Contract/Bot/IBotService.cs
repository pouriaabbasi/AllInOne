using Telegram.Bot;

namespace AllInOne.Services.Contract.Bot
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}