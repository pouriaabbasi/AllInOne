using System.Threading.Tasks;
using AllInOne.Services.Contract.Bot;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.DotNetCoreWebHook.Controllers
{
    [Route("bot/[controller]/[action]")]
    [Area("bot")]
    public class UpdateController : Controller
    { 
        private readonly IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Listener([FromBody]Update update)
        {
            await _updateService.EchoAsync(update);
            return Ok();
        }
    }
}
