using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Accounting;
using AllInOne.Data.Entity.LeitnerBox;
using AllInOne.Data.Entity.Todo;

namespace AllInOne.Data.Entity.Security
{
    [Table("User", Schema = "Security")]
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Username { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<List> Lists { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Box> Boxes { get; set; }
    }
}