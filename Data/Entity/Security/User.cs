using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Todo;

namespace AllInOne.Data.Entity.Security
{
    [Table("User", Schema = "Security")]
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<List> Lists { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}