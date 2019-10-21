using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.Data;
using AllInOne.Data.Entity.Bot;
using AllInOne.Models.Bot;
using AllInOne.Models.Security;
using AllInOne.Services.Contract.Bot;
using AllInOne.Services.Contract.Security;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

namespace AllInOne.Services.Implementation.Bot
{
    public class UpdateService : IUpdateService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<TelegramUser> telegramUserRepo;
        private readonly IBotService botService;
        private readonly IUserLib userLib;
        private static Dictionary<long, TelegramLoginStepModel> LoginTempCache;

        public UpdateService(
            IUnitOfWork unitOfWork,
            IRepository<TelegramUser> telegramUserRepo,
            IBotService botService,
            IUserLib userLib)
        {
            this.unitOfWork = unitOfWork;
            this.telegramUserRepo = telegramUserRepo;
            this.botService = botService;
            this.userLib = userLib;
        }

        public async Task EchoAsync(Update update)
        {
            var message = update.Message;
            var userModel = await GetTelegramUser(message.From, message.Chat.Id);
            if (userModel.NeedLogin) await LoginUser(userModel, message);
        }

        private async Task LoginUser(TelegramUserModel telegramUser, Message message)
        {
            if (LoginTempCache == null) LoginTempCache = new Dictionary<long, TelegramLoginStepModel>();
            var model = LoginTempCache.GetValueOrDefault(telegramUser.Id);
            if (model == null)
            {
                LoginTempCache.Add(telegramUser.Id, new TelegramLoginStepModel { Step = TelegramLoginStep.WaitingForUsername });
                await botService.Client.SendTextMessageAsync(message.Chat.Id, "You must first login");
                await botService.Client.SendTextMessageAsync(message.Chat.Id, "Please enter your username");
            }
            else if (model.Step == TelegramLoginStep.WaitingForUsername)
            {
                model.Username = message.Text;
                model.Step = TelegramLoginStep.WaiyingForPassword;
                await botService.Client.SendTextMessageAsync(message.Chat.Id, "Please enter your password");
            }
            else
            {
                model.Password = message.Text;
                LoginTempCache.Remove(telegramUser.Id);
                UserModel user = null;
                try
                {
                    user = await userLib.LoginAsync(new LoginModel
                    {
                        Password = model.Password,
                        Username = model.Username
                    });
                }
                catch { }
                if (user == null)
                    await botService.Client.SendTextMessageAsync(message.Chat.Id, "Username or Password is incorct");
                else
                {
                    telegramUser = await UpdateTelegramUser(telegramUser, user);
                    await botService.Client.SendTextMessageAsync(message.Chat.Id, "Successful!, Thanks");
                }
            }
        }

        private async Task<TelegramUserModel> GetTelegramUser(User model, long chatId)
        {
            var entity = await telegramUserRepo.FirstAsync(x => x.Id == model.Id);

            if (entity == null)
            {
                entity = new TelegramUser
                {
                    FirstName = model.FirstName,
                    Id = model.Id,
                    LanguageCode = model.LanguageCode,
                    LastName = model.LastName,
                    Username = model.Username,
                    ChatId = chatId
                };
                await telegramUserRepo.AddAsync(entity);
                await unitOfWork.CommitAsync();
            }
            return ConvertEntityToTelegramUserModel(entity);
        }

        private async Task<TelegramUserModel> UpdateTelegramUser(TelegramUserModel telegramUser, UserModel user)
        {
            var entity = await telegramUserRepo.FirstAsync(x => x.Id == telegramUser.Id);
            entity.UserId = user.Id;
            // telegramUserRepo.Update(entity);
            await unitOfWork.CommitAsync();
            return ConvertEntityToTelegramUserModel(entity);
        }

        private TelegramUserModel ConvertEntityToTelegramUserModel(TelegramUser entity)
        {
            return new TelegramUserModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                LanguageCode = entity.LanguageCode,
                Username = entity.Username,
                ChatId = entity.ChatId,
                UserId = entity.UserId
            };
        }
    }

    // Download Photo
    // var fileId = message.Photo.LastOrDefault()?.FileId;
    // var file = await _botService.Client.GetFileAsync(fileId);

    // var filename = file.FileId + "." + file.FilePath.Split('.').Last();

    // using (var saveImageStream = System.IO.File.Open(filename, FileMode.Create))
    // {
    //     await _botService.Client.DownloadFileAsync(file.FilePath, saveImageStream);
    // }

    // await _botService.Client.SendTextMessageAsync(message.Chat.Id, "Thx for the Pics");
}
