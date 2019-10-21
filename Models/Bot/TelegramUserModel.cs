namespace AllInOne.Models.Bot
{
    public class TelegramUserModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LanguageCode { get; set; }
        public string Username { get; set; }
        public long ChatId { get; set; }
        public long? UserId { get; set; }
        public bool NeedLogin => !UserId.HasValue || UserId == 0;
    }
}