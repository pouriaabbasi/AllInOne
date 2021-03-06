using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Todo
{
    [Table("Group", Schema = "Todo")]
    public class Group : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<List> Lists { get; set; }
    }
}