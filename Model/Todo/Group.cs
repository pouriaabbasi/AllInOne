using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Model.Todo
{
    [Table("Group", Schema="Todo")]
    public class Group : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<List> Lists { get; set; }
    }
}