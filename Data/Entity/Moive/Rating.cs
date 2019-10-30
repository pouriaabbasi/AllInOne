using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Data.Entity.Moive
{
    [Table("Rating", Schema = "Movie")]
    public class Rating : BaseEntity
    {
        public long MovieId { get; set; }
        [MaxLength(50)]
        public string SourceName { get; set; }
        [MaxLength(10)]
        public string Value { get; set; }

        public virtual Movie Movie { get; set; }
    }
}