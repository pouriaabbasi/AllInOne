using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Bot
{
    [Table("TelegramUser", Schema="Bot")]
    public class TelegramUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Username { get; set; }
        [MaxLength(100)]
        public string LanguageCode { get; set; }
        public long ChatId { get; set; }
        public long? UserId { get; set; }

        public virtual User User { get; set; }
    }
}