using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace AllInOne.Services.Contract.Bot
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update);
    }
}
