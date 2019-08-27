using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Model.Todo
{
    [Table("List", Schema="Todo")]
    public class List : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        
        [ForeignKey("Group")]
        public long? GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}