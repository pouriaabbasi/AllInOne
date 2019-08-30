using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Todo
{
    [Table("Item", Schema = "Todo")]
    public class Item : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public long? ListId { get; set; }
        public long UserId { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual List List { get; set; }
        public virtual User User { get; set; }
    }
}