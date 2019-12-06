using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Moive
{
    [Table("MovieCollection", Schema = "Movie")]
    public class MovieCollection : BaseEntity
    {
        public long UserId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<MovieCollectionDetail> MovieCollectionDetails { get; set; }
    }
}   