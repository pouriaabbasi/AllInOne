using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Todo
{
    [Table("List", Schema = "Todo")]
    public class List : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public long UserId { get; set; }
        public long? GroupId { get; set; }

        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
    }
}